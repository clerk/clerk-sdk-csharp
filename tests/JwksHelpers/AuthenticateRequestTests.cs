#nullable enable
namespace JwksHelpers.Tests
{
    using Clerk.BackendAPI.Helpers.Jwks;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Http;
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
        private readonly HostString _requestHost;

        public AuthenticateRequestTests(JwksHelpersFixture fixture)
        {
            _fixture = fixture;
            _requestHost = new HostString(_fixture.RequestHost);
        }

        [Fact]
        public async Task TestAuthenticateRequestNoSessionToken()
        {
            var arOptions = new AuthenticateRequestOptions(secretKey: "sk_test_SecretKey");

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            Assert.True(state.IsSignedOut());
            Assert.Equal(AuthErrorReason.SESSION_TOKEN_MISSING, state.ErrorReason);
            Assert.Null(state.Token);
            Assert.Null(state.Claims);
        }

        [Fact]
        public void TestAuthenticateRequestNoSecretKey()
        {
            var ex = Assert.Throws<AuthenticateRequestException>(
                () => new AuthenticateRequestOptions()
            );

            Assert.Equal(AuthErrorReason.SECRET_KEY_MISSING, ex.Reason);
            Assert.Null(ex.InnerException);
            Assert.Contains("Missing Clerk Secret Key.", ex.Message);
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_SESSION_TOKEN")]
        public async Task TestAuthenticateRequestCookie()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                audiences: _fixture.Audiences,
                authorizedParties: _fixture.AuthorizedParties
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Cookie", $"__session={_fixture.SessionToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            Utils.AssertStateAsync(state, _fixture.SessionToken);
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_SESSION_TOKEN")]
        public async Task TestAuthenticateRequestBearer()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                audiences: _fixture.Audiences,
                authorizedParties: _fixture.AuthorizedParties
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.SessionToken}");


            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            Utils.AssertStateAsync(state, _fixture.SessionToken);
        }

        [ConditionalFact("CLERK_JWT_KEY", "CLERK_SESSION_TOKEN")]
        public async Task TestAuthenticateRequestLocal()
        {
            var arOptions = new AuthenticateRequestOptions(
                jwtKey: _fixture.JwtKey,
                audiences: _fixture.Audiences,
                authorizedParties: _fixture.AuthorizedParties
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.SessionToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            Utils.AssertStateAsync(state, _fixture.SessionToken);
        }
    }
}
