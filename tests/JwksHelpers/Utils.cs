#nullable enable
namespace JwksHelpers.Tests
{
    using Clerk.BackendAPI.Helpers.Jwks;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using DotNetEnv;

    public class JwksHelpersFixture
    {
        public readonly string RequestHost = "http://localhost:3000";

        public readonly string? SecretKey;
        public readonly string? JwtKey;
        public readonly string SessionToken;
        public readonly string? ApiUrl;
        public readonly List<string>? Audiences;
        public readonly List<string> AuthorizedParties;

        public readonly string? MachineToken;
        public readonly string? OAuthToken;
        public readonly string? ApiKey;
        public readonly string? TestAudience;
        public readonly bool EnableRealIntegrationTests;

        public readonly string TestToken;
        public readonly string TestJwtKey;

        public JwksHelpersFixture()
        {
            // Loading logic for the .env file
            var currentDir = Directory.GetCurrentDirectory();
            var envPath = Path.Combine(currentDir, ".env");

            // If .env is not found in current directory, look for it in parent directories
            while (!File.Exists(envPath) && Directory.GetParent(currentDir) != null)
            {
                currentDir = Directory.GetParent(currentDir)!.FullName;
                envPath = Path.Combine(currentDir, ".env");
            }

            if (File.Exists(envPath))
            {
                DotNetEnv.Env.Load(envPath);
            }
            
            var enableRealTests = Environment.GetEnvironmentVariable("ENABLE_REAL_INTEGRATION_TESTS");
            EnableRealIntegrationTests = string.Equals(enableRealTests, "true", StringComparison.OrdinalIgnoreCase);

            SecretKey = Environment.GetEnvironmentVariable("CLERK_SECRET_KEY");
            JwtKey = Environment.GetEnvironmentVariable("CLERK_JWT_KEY");
            ApiUrl = Environment.GetEnvironmentVariable("CLERK_API_URL");
            SessionToken = Environment.GetEnvironmentVariable("CLERK_SESSION_TOKEN") ?? "";
            
            MachineToken = Environment.GetEnvironmentVariable("CLERK_MACHINE_TOKEN");
            OAuthToken = Environment.GetEnvironmentVariable("CLERK_OAUTH_TOKEN");
            ApiKey = Environment.GetEnvironmentVariable("CLERK_API_KEY");
            TestAudience = Environment.GetEnvironmentVariable("CLERK_TEST_AUDIENCE") ?? "test-api";
            
            Audiences = null;
            AuthorizedParties = new List<string> { 
                Environment.GetEnvironmentVariable("CLERK_TEST_AUTHORIZED_PARTY") ?? RequestHost 
            };

            (TestToken, TestJwtKey) = Utils.GenerateTokenKeyPair(
                keyId: "ins_abcdefghijklmnopqrstuvwxyz0",
                issuedAt: DateTime.UtcNow.AddMinutes(-1),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(1),
                audience: RequestHost,
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

    public class RealIntegrationFactAttribute : FactAttribute
    {
        public RealIntegrationFactAttribute(params string[] requiredEnvVars)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var envPath = Path.Combine(currentDir, ".env");
            
            // Look for .env file in current directory and parent directories
            while (!File.Exists(envPath) && Directory.GetParent(currentDir) != null)
            {
                currentDir = Directory.GetParent(currentDir)!.FullName;
                envPath = Path.Combine(currentDir, ".env");
            }
            
            if (File.Exists(envPath))
            {
                try
                {
                    DotNetEnv.Env.Load(envPath);
                }
                catch (Exception ex)
                {
                    // Continue without .env file if parsing fails
                }
            }

            var enableRealTests = Environment.GetEnvironmentVariable("ENABLE_REAL_INTEGRATION_TESTS");
            
            if (!string.Equals(enableRealTests, "true", StringComparison.OrdinalIgnoreCase))
            {
                Skip = "Real integration tests are disabled. Set ENABLE_REAL_INTEGRATION_TESTS=true to enable.";
                return;
            }

            // Check if all required environment variables are present
            var missingVars = requiredEnvVars.Where(varName => string.IsNullOrEmpty(Environment.GetEnvironmentVariable(varName))).ToList();
            if (missingVars.Any())
            {
                Skip = $"Missing required environment variables: {string.Join(", ", missingVars)}";
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
