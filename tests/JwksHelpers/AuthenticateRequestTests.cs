#nullable enable
namespace JwksHelpers.Tests
{
    using Clerk.BackendAPI.Helpers.Jwks;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Text;
    using Xunit;

    public class AuthenticateRequestTests : IClassFixture<JwksHelpersFixture>
    {
        private readonly JwksHelpersFixture _fixture;
        private readonly Uri _requestUri;

        public AuthenticateRequestTests(JwksHelpersFixture fixture)
        {
            _fixture = fixture;
            _requestUri = new Uri(_fixture.RequestUrl);
        }

        [Fact]
        public async Task TestAuthenticateRequestNoSesstionToken ()
        {
            var arOptions = new AuthenticateRequestOptions(secretKey: "sk_test_SecretKey");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _requestUri);
            var state = await AuthenticateRequest.AuthenticateRequestAsync(request, arOptions);

                Assert.True(state.IsSignedOut());
                Assert.Equal(AuthErrorReason.SESSION_TOKEN_MISSING, state.ErrorReason);
                Assert.Null(state.Token);
                Assert.Null(state.Claims);
        }

        [Fact]
        public void TestAuthenticateRequestNoSecretKey ()
        {
            var ex = Assert.Throws<AuthenticateRequestException>(
                () => new AuthenticateRequestOptions()
            );

            Assert.Equal(AuthErrorReason.SECRET_KEY_MISSING, ex.Reason);
            Assert.Null(ex.InnerException);
            Assert.Contains("Missing Clerk Secret Key.", ex.Message);
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_SESSION_TOKEN")]
        public async Task TestAuthenticateRequestCookie ()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                audiences: _fixture.Audiences,
                authorizedParties: _fixture.AuthorizedParties
            );

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _requestUri);
            request.Headers.Add("Cookie", $"__session={_fixture.SessionToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(request, arOptions);

            Utils.AssertStateAsync(state, _fixture.SessionToken);
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_SESSION_TOKEN")]
        public async Task TestAuthenticateRequestBearer ()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                audiences: _fixture.Audiences,
                authorizedParties: _fixture.AuthorizedParties
            );

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _requestUri);
            request.Headers.Add("Authorization", $"Bearer {_fixture.SessionToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(request, arOptions);

            Utils.AssertStateAsync(state, _fixture.SessionToken);
        }

        [ConditionalFact("CLERK_JWT_KEY", "CLERK_SESSION_TOKEN")]
        public async Task TestAuthenticateRequestLocal ()
        {
            var arOptions = new AuthenticateRequestOptions(
                jwtKey: _fixture.JwtKey,
                audiences: _fixture.Audiences,
                authorizedParties: _fixture.AuthorizedParties
            );

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _requestUri);
            request.Headers.Add("Authorization", $"Bearer {_fixture.SessionToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(request, arOptions);

            Utils.AssertStateAsync(state, _fixture.SessionToken);
        }
    }
}
