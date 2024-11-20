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
                audiences: new string[] { fixture.RequestUrl }
            );

            var claims = await VerifyToken.VerifyTokenAsync(fixture.TestToken, vtOptions);
            var audClaim = claims.FindFirst("aud");
            Assert.NotNull(audClaim);
            Assert.Equal(fixture.RequestUrl, audClaim.Value);


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

    }
}
