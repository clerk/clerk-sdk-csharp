#nullable enable
namespace JwksHelpers.Tests
{
    using Clerk.BackendAPI.Helpers.Jwks;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class JwksHelpersFixture
    {
        public readonly string RequestUrl = "http://localhost:3000";

        public readonly string? SecretKey;
        public readonly string? JwtKey;
        public readonly string SessionToken;
        public readonly string? ApiUrl;
        public readonly List<string>? Audiences;
        public readonly List<string> AuthorizedParties;

        public readonly string TestToken;
        public readonly string TestJwtKey;

        public JwksHelpersFixture()
        {
            SecretKey = System.Environment.GetEnvironmentVariable("CLERK_SECRET_KEY");
            JwtKey = System.Environment.GetEnvironmentVariable("CLERK_JWT_KEY");
            ApiUrl = System.Environment.GetEnvironmentVariable("CLERK_API_URL");
            SessionToken = System.Environment.GetEnvironmentVariable("CLERK_SESSION_TOKEN") ?? "";
            Audiences = null;
            AuthorizedParties = new List<string> { RequestUrl };

            (TestToken, TestJwtKey) = Utils.GenerateTokenKeyPair(
                keyId: "ins_abcdefghijklmnopqrstuvwxyz0",
                issuedAt: DateTime.UtcNow.AddMinutes(-1),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(1),
                audience: RequestUrl,
                authorizedParties: AuthorizedParties);
        }
    }

    public class ConditionalFactAttribute : FactAttribute
    {
        public ConditionalFactAttribute(params string[] envVars)
        {
            var missingEnvVars = new List<string>();
            foreach (var envVar in envVars)
            {
                if (string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable(envVar)))
                {
                    missingEnvVars.Add(envVar);
                }
            }
            if (missingEnvVars.Count > 0)
            {
                Skip = $"Missing environment variable(s): {string.Join(", ", missingEnvVars)}.";
            }
        }
    }

    public class Utils
    {

        internal static void WarnTokenIsExpired(string? message = "")
        {
            System.Console.WriteLine($"WARNING: the provided session token is expired! {message}");
        }

        internal static async Task AssertClaimsAsync(string sessionToken, VerifyTokenOptions options)
        {
            bool expired = false;
            ClaimsPrincipal? claims = null;

            try
            {
                claims = await VerifyToken.VerifyTokenAsync(sessionToken, options);
            }
            catch (TokenVerificationException ex)
            {
                if (ex.Reason != TokenVerificationErrorReason.TOKEN_EXPIRED)
                {
                    throw;
                }

                Assert.IsType<SecurityTokenExpiredException>(ex.InnerException);
                Assert.Contains("Lifetime validation failed. The token is expired.", ex.InnerException.Message);
                expired = true;
                WarnTokenIsExpired();
            }

            if (!expired)
            {
                Assert.NotNull(claims);
                Assert.NotNull(claims.FindFirst("iss"));
            }
        }

        internal static void AssertStateAsync(RequestState state, string token)
        {
            if (state.IsSignedIn())
            {
                Assert.Null(state.ErrorReason);
                Assert.Equal(token, state.Token);
                Assert.NotNull(state.Claims);
            }
            else
            {
                Assert.Equal(TokenVerificationErrorReason.TOKEN_EXPIRED, state.ErrorReason);
                Assert.Null(state.Token);
                Assert.Null(state.Claims);
                WarnTokenIsExpired();
            }
        }

        internal static Tuple<string, string> GenerateTokenKeyPair(
            string? keyId = null,
            DateTime? issuedAt = null,
            DateTime? notBefore = null,
            DateTime? expires = null,
            string? audience = null,
            IEnumerable<string>? authorizedParties = null)
        {
            var rsa = RSA.Create(2048);
            var rsaSecurityKey = new RsaSecurityKey(rsa)
            {
                KeyId = keyId ?? "ins_abcdefghijklmnopqrstuvwxyz0"
            };
            var signingCredentials = new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256);

            var subjectClaims = new List<Claim> { new Claim(ClaimTypes.Name, "Test") };
            if (authorizedParties != null)
            {
                foreach (var party in authorizedParties)
                {
                    subjectClaims.Add(new Claim("azp", party));
                }
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(subjectClaims),
                Issuer = "https://test.com",
                Audience = audience,
                IssuedAt = issuedAt ?? DateTime.UtcNow.AddMinutes(-1),
                NotBefore = notBefore ?? DateTime.UtcNow,
                Expires = expires ?? DateTime.UtcNow.AddMinutes(1)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();
            var pem = new StringBuilder();
            pem.AppendLine("-----BEGIN PUBLIC KEY-----");
            pem.AppendLine(Convert.ToBase64String(publicKeyBytes, Base64FormattingOptions.InsertLineBreaks));
            pem.AppendLine("-----END PUBLIC KEY-----");

            return new Tuple<string, string>(tokenString, pem.ToString());
        }
    }
}
