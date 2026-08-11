#nullable enable
namespace JwksHelpers.Tests
{
    using Clerk.BackendAPI.Helpers.Jwks;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Net;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using Xunit;

    /// <summary>
    ///     Regression tests for AISEC-83. The static JWKS cache was keyed on the bare kid.
    ///     Because a Clerk kid is the instance id, a key cached for one instance was a direct
    ///     hit for another instance's verification in the same process, and the lookup
    ///     short-circuits before SecretKey is ever consulted. Combined with
    ///     ValidateIssuer = false, a token minted by instance B authenticated against
    ///     instance A.
    /// </summary>
    public class JwksCacheScopingTests : IDisposable
    {
        private readonly HttpListener listener = new HttpListener();
        private readonly string apiUrl;
        private readonly Dictionary<string, string> jwksBySecretKey = new Dictionary<string, string>();
        private readonly List<string> fetchLog = new List<string>();

        public JwksCacheScopingTests()
        {
            var port = FreePort();
            apiUrl = $"http://127.0.0.1:{port}";
            listener.Prefixes.Add($"{apiUrl}/");
            listener.Start();
            _ = Task.Run(ServeAsync);
        }

        public void Dispose() => listener.Close();

        [Fact]
        public async Task CachedKeyIsNotServedToAnotherInstance()
        {
            const string secretA = "sk_test_scoping_a";
            const string secretB = "sk_test_scoping_b";

            var (_, jwksA) = MakeTenant("ins_scoping_a");
            var (tokenB, jwksB) = MakeTenant("ins_scoping_b");
            jwksBySecretKey[secretA] = jwksA;
            jwksBySecretKey[secretB] = jwksB;

            var optionsA = new VerifyTokenOptions(secretKey: secretA, apiUrl: apiUrl);
            var optionsB = new VerifyTokenOptions(secretKey: secretB, apiUrl: apiUrl);

            // A legitimate tenant-B verification warms the cache with tenant B's key.
            await VerifyToken.VerifyTokenAsync(tokenB, optionsB);
            Assert.Equal(new[] { secretB }, fetchLog);

            // The same token under tenant A must miss the cache and force a fetch
            // under tenant A's secret key, whose JWKS has no such kid.
            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(tokenB, optionsA)
            );
            Assert.Equal(TokenVerificationErrorReason.JWK_KID_MISMATCH, ex.Reason);
            Assert.Equal(new[] { secretB, secretA }, fetchLog);

            // Tenant B's own entry is still cached.
            await VerifyToken.VerifyTokenAsync(tokenB, optionsB);
            Assert.Equal(new[] { secretB, secretA }, fetchLog);
        }

        private static (string token, string jwks) MakeTenant(string kid)
        {
            var rsa = RSA.Create(2048);
            var signingCredentials = new SigningCredentials(
                new RsaSecurityKey(rsa) { KeyId = kid }, SecurityAlgorithms.RsaSha256);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(handler.CreateToken(new SecurityTokenDescriptor
            {
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(new[] { new Claim("sub", $"user_{kid}") }),
                Issuer = $"https://clerk.{kid}.test",
                IssuedAt = DateTime.UtcNow.AddMinutes(-1),
                NotBefore = DateTime.UtcNow.AddMinutes(-1),
                Expires = DateTime.UtcNow.AddMinutes(10)
            }));

            var parameters = rsa.ExportParameters(false);
            var jwks = "{\"keys\":[{\"use\":\"sig\",\"kty\":\"RSA\",\"alg\":\"RS256\""
                + $",\"kid\":\"{kid}\""
                + $",\"n\":\"{Base64Url(parameters.Modulus!)}\""
                + $",\"e\":\"{Base64Url(parameters.Exponent!)}\"}}]}}";

            return (token, jwks);
        }

        private static string Base64Url(byte[] bytes) =>
            Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');

        private static int FreePort()
        {
            var socket = new System.Net.Sockets.TcpListener(IPAddress.Loopback, 0);
            socket.Start();
            var port = ((IPEndPoint)socket.LocalEndpoint).Port;
            socket.Stop();
            return port;
        }

        private async Task ServeAsync()
        {
            while (listener.IsListening)
            {
                HttpListenerContext context;
                try
                {
                    context = await listener.GetContextAsync();
                }
                catch (Exception)
                {
                    return;
                }

                var secretKey = (context.Request.Headers["Authorization"] ?? "").Replace("Bearer ", "");
                if (jwksBySecretKey.TryGetValue(secretKey, out var jwks))
                {
                    lock (fetchLog)
                    {
                        fetchLog.Add(secretKey);
                    }

                    var body = System.Text.Encoding.UTF8.GetBytes(jwks);
                    context.Response.ContentType = "application/json";
                    await context.Response.OutputStream.WriteAsync(body, 0, body.Length);
                }
                else
                {
                    context.Response.StatusCode = 401;
                }

                context.Response.Close();
            }
        }
    }
}
