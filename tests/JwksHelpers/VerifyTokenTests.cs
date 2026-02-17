#nullable enable
namespace JwksHelpers.Tests
{
    using Xunit;
    using Clerk.BackendAPI.Helpers.Jwks;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using System.Security.Cryptography;
    using System.Linq;

    public class VerifyTokenTests : IClassFixture<JwksHelpersFixture>
    {
        private readonly JwksHelpersFixture fixture;

        public VerifyTokenTests(JwksHelpersFixture jwksHelpersFixture)
        {
            fixture = jwksHelpersFixture;
        }

        [Fact]
        public void TestVerifyTokenNoSecretKey()
        {

            var ex = Assert.Throws<TokenVerificationException>(
                () => new VerifyTokenOptions()
            );

            Assert.Equal(TokenVerificationErrorReason.SECRET_KEY_MISSING, ex.Reason);
            Assert.Contains("Missing Clerk Secret Key.", ex.ToString());
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public async Task TestVerifyTokenInvalidSecretKey()
        {
            var vtOptions = new VerifyTokenOptions(secretKey: "sk_test_invalid");

            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(fixture.TestToken, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.JWK_FAILED_TO_LOAD, ex.Reason);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public async Task TestVerifyTokenInvalidJwtKey()
        {
            var (token, jwtKey) = Utils.GenerateTokenKeyPair();
            var vtOptions = new VerifyTokenOptions(jwtKey: "invalid.jwt.key");

            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(fixture.TestToken, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.JWK_LOCAL_INVALID, ex.Reason);
            Assert.IsType<System.ArgumentException>(ex.InnerException);
            Assert.Contains("No supported key formats were found.", ex.InnerException.Message);
        }

        [Fact]
        public async Task TestVerifyTokenInvalidSignature()
        {
            var vtOptions = new VerifyTokenOptions(
                jwtKey: fixture.TestJwtKey!.Replace("+", "0")  // tampering with the key
            );

            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(fixture.TestToken, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.TOKEN_INVALID_SIGNATURE, ex.Reason);
            Assert.IsAssignableFrom<SecurityTokenInvalidSignatureException>(ex.InnerException);
        }

        [Fact]
        public async Task TestVerifyTokenNotActiveYet()
        {
            var (token, jwtKey) = Utils.GenerateTokenKeyPair(
                notBefore: DateTime.UtcNow.AddSeconds(10)
            );

            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);
            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(token, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.TOKEN_NOT_ACTIVE_YET, ex.Reason);
            Assert.IsType<SecurityTokenNotYetValidException>(ex.InnerException);
            Assert.Contains("Lifetime validation failed.", ex.InnerException.Message);
        }

        [Fact]
        public async Task TestVerifyTokenClockSkew()
        {
            var nbfDateTime = DateTime.UtcNow.AddSeconds(10);
            var nbfTimeStamp = ((DateTimeOffset)nbfDateTime).ToUnixTimeSeconds();

            var (token, jwtKey) = Utils.GenerateTokenKeyPair(
                issuedAt: DateTime.UtcNow.AddMinutes(-1),
                notBefore: nbfDateTime,
                expires: DateTime.UtcNow.AddMinutes(2)
            );

            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey, clockSkewInMs: 0);
            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(token, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.TOKEN_NOT_ACTIVE_YET, ex.Reason);
            Assert.IsType<SecurityTokenNotYetValidException>(ex.InnerException);

            vtOptions = new VerifyTokenOptions(jwtKey: jwtKey, clockSkewInMs: 10000);
            var claims = await VerifyToken.VerifyTokenAsync(token, vtOptions);
            var nbfClaim = claims.FindFirst("nbf");
            Assert.NotNull(nbfClaim);
            Assert.Equal(nbfTimeStamp.ToString(), nbfClaim.Value);
        }

        [Fact]
        public async Task TestVerifyTokenConsecutiveCallsWithSameKey()
        {
            var (token, jwtKey) = Utils.GenerateTokenKeyPair();

            // Poison the global CryptoProviderFactory cache with a disposed RSA key (#75)
            var rsa = RSA.Create();
            rsa.ImportFromPem(jwtKey.ToCharArray());
            var staleKey = new RsaSecurityKey(rsa);
            var factory = CryptoProviderFactory.Default;
            var cachedProvider = factory.CreateForVerifying(staleKey, SecurityAlgorithms.RsaSha256);
            rsa.Dispose();

            try
            {
                var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);

                for (int i = 0; i < 5; i++)
                {
                    var claims = await VerifyToken.VerifyTokenAsync(token, vtOptions);
                    Assert.NotNull(claims);
                }
            }
            finally
            {
                factory.ReleaseSignatureProvider(cachedProvider);
            }
        }

        [Fact]
        public async Task TestVerifyTokenExpired()
        {
            var (token, jwtKey) = Utils.GenerateTokenKeyPair(
                issuedAt: DateTime.UtcNow.AddMinutes(-3),
                notBefore: DateTime.UtcNow.AddMinutes(-2),
                expires: DateTime.UtcNow.AddMinutes(-1)
            );

            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);
            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(token, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.TOKEN_EXPIRED, ex.Reason);
            Assert.IsType<SecurityTokenExpiredException>(ex.InnerException);
            Assert.Contains("Lifetime validation failed.", ex.InnerException.Message);
        }

        [Fact]
        public async Task TestVerifyTokenIssuedInTheFuture()
        {
            var (token, jwtKey) = Utils.GenerateTokenKeyPair(
                issuedAt: DateTime.UtcNow.AddMinutes(1),
                notBefore: DateTime.UtcNow.AddMinutes(-1),
                expires: DateTime.UtcNow.AddMinutes(2)
            );

            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);
            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(token, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.TOKEN_IAT_IN_THE_FUTURE, ex.Reason);
            Assert.Null(ex.InnerException);
        }

        [Fact]
        public async Task TestVerifyTokenInvalidAudience()
        {
            var vtOptions = new VerifyTokenOptions(
                jwtKey: fixture.TestJwtKey,
                audiences: new string[] { fixture.RequestHost }
            );

            var claims = await VerifyToken.VerifyTokenAsync(fixture.TestToken, vtOptions);
            var audClaim = claims.FindFirst("aud");
            Assert.NotNull(audClaim);
            Assert.Equal(fixture.RequestHost, audClaim.Value);


            vtOptions = new VerifyTokenOptions(
                jwtKey: fixture.TestJwtKey,
                audiences: new List<string> { "invalid.audience" }
            );

            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(fixture.TestToken, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.TOKEN_INVALID_AUDIENCE, ex.Reason);
            Assert.IsType<SecurityTokenInvalidAudienceException>(ex.InnerException);
            Assert.Contains("Audience validation failed.", ex.InnerException.Message);
        }

        [Fact]
        public async Task TestVerifyTokenInvalidAuthorizedParties()
        {
            var vtOptions = new VerifyTokenOptions(
                jwtKey: fixture.TestJwtKey,
                authorizedParties: fixture.AuthorizedParties
            );

            var claims = await VerifyToken.VerifyTokenAsync(fixture.TestToken, vtOptions);
            var azpClaim = claims.FindFirst("azp");
            Assert.NotNull(azpClaim);
            Assert.Contains(azpClaim.Value, fixture.AuthorizedParties);

            vtOptions = new VerifyTokenOptions(
                jwtKey: fixture.TestJwtKey,
                authorizedParties: new string[] { "http://only.authorized.party" }
            );

            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(fixture.TestToken, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.TOKEN_INVALID_AUTHORIZED_PARTIES, ex.Reason);
            Assert.Null(ex.InnerException);

        }

        [ConditionalFact("CLERK_SECRET_KEY")]
        public async Task TestVerifyTokenInvalidToken()
        {
            var vtOptions = new VerifyTokenOptions(secretKey: fixture.SecretKey);

            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync("invalid.session.token", vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.TOKEN_INVALID, ex.Reason);
            Assert.IsType<ArgumentException>(ex.InnerException);
            Assert.Contains("IDX12729: Unable to decode the header", ex.InnerException.Message);
        }


        [ConditionalFact("CLERK_SECRET_KEY")]
        public async Task TestVerifyTokenInvalidKid()
        {
            var token = Utils.GenerateTokenKeyPair().Item1;

            var vtOptions = new VerifyTokenOptions(secretKey: fixture.SecretKey);

            var ex = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(token, vtOptions)
            );

            Assert.Equal(TokenVerificationErrorReason.JWK_KID_MISMATCH, ex.Reason);
            Assert.Null(ex.InnerException);
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_SESSION_TOKEN")]
        public async Task TestVerifyTokenRemoteOk()
        {
            var vtOptions = new VerifyTokenOptions(
                secretKey: fixture.SecretKey,
                audiences: fixture.Audiences,
                authorizedParties: fixture.AuthorizedParties,
                apiUrl: fixture.ApiUrl
            );

            await Utils.AssertClaimsAsync(fixture.SessionToken, vtOptions);
        }

        [ConditionalFact("CLERK_JWT_KEY", "CLERK_SESSION_TOKEN")]
        public async Task TestVerifyTokenLocalOk()
        {
            var vtOptions = new VerifyTokenOptions(
                jwtKey: fixture.JwtKey,
                audiences: fixture.Audiences,
                authorizedParties: fixture.AuthorizedParties,
                apiUrl: fixture.ApiUrl
            );

            await Utils.AssertClaimsAsync(fixture.SessionToken, vtOptions);
        }

        [Fact]
        public async Task TestVerifyTokenWithOrganizationClaims()
        {
            var orgClaims = new Dictionary<string, object>
            {
                ["id"] = "org_123",
                ["slg"] = "test-org",
                ["rol"] = "admin",
                ["per"] = "read,write",
                ["fpm"] = "3,1"
            };
            var claims = new List<Claim>
            {
                new Claim("v", "2"),
                new Claim("o", JsonConvert.SerializeObject(orgClaims)),
                new Claim("fea", "o:users,o:settings")
            };
            var (token, jwtKey) = Utils.GenerateTokenKeyPair(
                keyId: "ins_abcdefghijklmnopqrstuvwxyz0",
                issuedAt: DateTime.UtcNow.AddMinutes(-1),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(1)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims);
            foreach (var claim in claims)
                identity.AddClaim(claim);
            var rsa = RSA.Create();
            rsa.ImportFromPem(jwtKey.ToCharArray());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256),
                Subject = identity,
                Issuer = jwtToken.Issuer,
                Audience = jwtToken.Audiences.FirstOrDefault(),
                IssuedAt = jwtToken.IssuedAt,
                NotBefore = jwtToken.ValidFrom,
                Expires = jwtToken.ValidTo
            };
            var newToken = tokenHandler.CreateToken(tokenDescriptor);
            var newTokenString = tokenHandler.WriteToken(newToken);
            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);
            var result = await VerifyToken.VerifyTokenAsync(newTokenString, vtOptions);
            Assert.Equal("org_123", result.FindFirst("org_id")?.Value);
            Assert.Equal("test-org", result.FindFirst("org_slug")?.Value);
            Assert.Equal("admin", result.FindFirst("org_role")?.Value);
            var orgPermissions = result.FindFirst("org_permissions")?.Value;
            Assert.NotNull(orgPermissions);
            Assert.Contains("org:users:read", orgPermissions);
            Assert.Contains("org:users:write", orgPermissions);
            Assert.Contains("org:settings:read", orgPermissions);
        }

        [Fact]
        public async Task TestVerifyTokenWithInvalidOrganizationVersion()
        {
            var orgClaims = new Dictionary<string, object>
            {
                ["id"] = "org_123",
                ["slg"] = "test-org",
                ["rol"] = "admin"
            };
            var claims = new List<Claim>
            {
                new Claim("v", "1"),
                new Claim("o", JsonConvert.SerializeObject(orgClaims)),
                new Claim("fea", "o:users")
            };
            var (token, jwtKey) = Utils.GenerateTokenKeyPair(
                keyId: "ins_abcdefghijklmnopqrstuvwxyz0",
                issuedAt: DateTime.UtcNow.AddMinutes(-1),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(1)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims);
            foreach (var claim in claims)
                identity.AddClaim(claim);
            var rsa = RSA.Create();
            rsa.ImportFromPem(jwtKey.ToCharArray());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256),
                Subject = identity,
                Issuer = jwtToken.Issuer,
                Audience = jwtToken.Audiences.FirstOrDefault(),
                IssuedAt = jwtToken.IssuedAt,
                NotBefore = jwtToken.ValidFrom,
                Expires = jwtToken.ValidTo
            };
            var newToken = tokenHandler.CreateToken(tokenDescriptor);
            var newTokenString = tokenHandler.WriteToken(newToken);
            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);
            var result = await VerifyToken.VerifyTokenAsync(newTokenString, vtOptions);
            Assert.Null(result.FindFirst("org_id"));
            Assert.Null(result.FindFirst("org_slug"));
            Assert.Null(result.FindFirst("org_role"));
            Assert.Null(result.FindFirst("org_permissions"));
        }

        [Fact]
        public async Task TestVerifyTokenWithMissingOrganizationClaim()
        {
            var claims = new List<Claim>
            {
                new Claim("v", "2"),
                new Claim("fea", "o:users")
            };
            var (token, jwtKey) = Utils.GenerateTokenKeyPair(
                keyId: "ins_abcdefghijklmnopqrstuvwxyz0",
                issuedAt: DateTime.UtcNow.AddMinutes(-1),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(1)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims);
            foreach (var claim in claims)
                identity.AddClaim(claim);
            var rsa = RSA.Create();
            rsa.ImportFromPem(jwtKey.ToCharArray());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256),
                Subject = identity,
                Issuer = jwtToken.Issuer,
                Audience = jwtToken.Audiences.FirstOrDefault(),
                IssuedAt = jwtToken.IssuedAt,
                NotBefore = jwtToken.ValidFrom,
                Expires = jwtToken.ValidTo
            };
            var newToken = tokenHandler.CreateToken(tokenDescriptor);
            var newTokenString = tokenHandler.WriteToken(newToken);
            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);
            var result = await VerifyToken.VerifyTokenAsync(newTokenString, vtOptions);
            Assert.Null(result.FindFirst("org_id"));
            Assert.Null(result.FindFirst("org_slug"));
            Assert.Null(result.FindFirst("org_role"));
            Assert.Null(result.FindFirst("org_permissions"));
        }

        [Fact]
        public async Task TestVerifyTokenPreservesOriginalClaims()
        {
            var orgClaims = new Dictionary<string, object>
            {
                ["id"] = "org_123",
                ["slg"] = "test-org",
                ["rol"] = "admin"
            };
            var claims = new List<Claim>
            {
                new Claim("v", "2"),
                new Claim("o", JsonConvert.SerializeObject(orgClaims)),
                new Claim("fea", "o:users"),
                new Claim("sub", "user_123"),
                new Claim("iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())
            };
            var identity = new ClaimsIdentity(claims);
            var rsa = RSA.Create();
            var keyPair = Utils.GenerateTokenKeyPair(
                keyId: "ins_abcdefghijklmnopqrstuvwxyz0",
                issuedAt: DateTime.UtcNow.AddMinutes(-1),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(1)
            );
            var jwtKey = keyPair.Item2;
            rsa.ImportFromPem(jwtKey.ToCharArray());
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256),
                Subject = identity,
                Issuer = "https://test.com",
                Audience = "test-audience",
                IssuedAt = DateTime.UtcNow.AddMinutes(-1),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(1)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);
            var result = await VerifyToken.VerifyTokenAsync(tokenString, vtOptions);
            // Debug output
            foreach (var c in result.Claims) {
                Console.WriteLine($"CLAIM: {c.Type} = {c.Value}");
            }
            Assert.Equal("user_123", result.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Assert.NotNull(result.FindFirst("iat"));
            Assert.Equal("org_123", result.FindFirst("org_id")?.Value);
            Assert.Equal("test-org", result.FindFirst("org_slug")?.Value);
            Assert.Equal("admin", result.FindFirst("org_role")?.Value);
        }

        [Fact]
        public async Task TestVerifyTokenOrganizationClaimsMatchDocumentation()
        {
            var orgClaims = new Dictionary<string, object>
            {
                ["id"] = "org_123",
                ["slg"] = "test-org",
                ["rol"] = "admin",
                ["per"] = "read,write,manage",
                ["fpm"] = "7,3,1"
            };
            var claims = new List<Claim>
            {
                new Claim("v", "2"),
                new Claim("o", JsonConvert.SerializeObject(orgClaims)),
                new Claim("fea", "o:users,o:settings,o:billing")
            };
            var identity = new ClaimsIdentity(claims);
            var rsa = RSA.Create();
            var keyPair = Utils.GenerateTokenKeyPair(
                keyId: "ins_abcdefghijklmnopqrstuvwxyz0",
                issuedAt: DateTime.UtcNow.AddMinutes(-1),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(1)
            );
            var jwtKey = keyPair.Item2;
            rsa.ImportFromPem(jwtKey.ToCharArray());
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256),
                Subject = identity,
                Issuer = "https://test.com",
                Audience = "test-audience",
                IssuedAt = DateTime.UtcNow.AddMinutes(-1),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(1)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);
            var result = await VerifyToken.VerifyTokenAsync(tokenString, vtOptions);
            // Debug output
            foreach (var c in result.Claims) {
                Console.WriteLine($"CLAIM: {c.Type} = {c.Value}");
            }
            var orgIdClaim = result.FindFirst("org_id");
            Assert.NotNull(orgIdClaim);
            Assert.Equal("org_123", orgIdClaim.Value);
            var orgSlugClaim = result.FindFirst("org_slug");
            Assert.NotNull(orgSlugClaim);
            Assert.Equal("test-org", orgSlugClaim.Value);
            var orgRoleClaim = result.FindFirst("org_role");
            Assert.NotNull(orgRoleClaim);
            Assert.Equal("admin", orgRoleClaim.Value);
            var orgPermissionsClaim = result.FindFirst("org_permissions");
            Assert.NotNull(orgPermissionsClaim);
            var permissions = orgPermissionsClaim.Value.Split(',');
            Assert.Contains("org:users:read", permissions);
            Assert.Contains("org:users:write", permissions);
            Assert.Contains("org:users:manage", permissions);
            Assert.Contains("org:settings:read", permissions);
            Assert.Contains("org:settings:write", permissions);
            Assert.Contains("org:billing:read", permissions);
            Assert.DoesNotContain(permissions, p => p.StartsWith("system:"));
        }

        [Fact]
        public async Task TestVerifyTokenOrganizationClaimsCompactFormat()
        {
            var orgClaims = new Dictionary<string, object>
            {
                ["id"] = "org_123",
                ["slg"] = "test-org",
                ["rol"] = "admin",
                ["per"] = "read,write",
                ["fpm"] = "3,1"
            };
            var claims = new List<Claim>
            {
                new Claim("v", "2"),
                new Claim("o", JsonConvert.SerializeObject(orgClaims)),
                new Claim("fea", "o:users,o:settings")
            };
            var (token, jwtKey) = Utils.GenerateTokenKeyPair(
                keyId: "ins_abcdefghijklmnopqrstuvwxyz0",
                issuedAt: DateTime.UtcNow.AddMinutes(-1),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(1)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwtToken.Claims);
            foreach (var claim in claims)
                identity.AddClaim(claim);
            var rsa = RSA.Create();
            rsa.ImportFromPem(jwtKey.ToCharArray());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256),
                Subject = identity,
                Issuer = jwtToken.Issuer,
                Audience = jwtToken.Audiences.FirstOrDefault(),
                IssuedAt = jwtToken.IssuedAt,
                NotBefore = jwtToken.ValidFrom,
                Expires = jwtToken.ValidTo
            };
            var newToken = tokenHandler.CreateToken(tokenDescriptor);
            var newTokenString = tokenHandler.WriteToken(newToken);
            var vtOptions = new VerifyTokenOptions(jwtKey: jwtKey);
            var result = await VerifyToken.VerifyTokenAsync(newTokenString, vtOptions);
            var orgClaim = result.FindFirst("o");
            Assert.NotNull(orgClaim);
            var deserializedOrgClaims = JsonConvert.DeserializeObject<Dictionary<string, object>>(orgClaim.Value);
            Assert.NotNull(deserializedOrgClaims);
            Assert.Equal("3,1", deserializedOrgClaims["fpm"].ToString());
            var orgPermissionsClaim = result.FindFirst("org_permissions");
            Assert.NotNull(orgPermissionsClaim);
            var permissions = orgPermissionsClaim.Value.Split(',');
            Assert.Contains("org:users:read", permissions);
            Assert.Contains("org:users:write", permissions);
            Assert.Contains("org:settings:read", permissions);
            Assert.DoesNotContain("org:settings:write", permissions);
        }

    }
}
