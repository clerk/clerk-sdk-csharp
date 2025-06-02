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

        #region Basic Authentication Tests

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

        #endregion

        #region Real Integration Tests for New Token Types

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN")]
        public async Task TestRealMachineTokenAuthentication()
        {
            // Ensure the fixture has the required tokens from environment variables
            Assert.NotNull(_fixture.SecretKey);
            Assert.NotNull(_fixture.MachineToken);
            
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                acceptsToken: new[] { "machine_token" }
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.MachineToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Verify successful authentication
            Assert.False(state.IsSignedOut());
            Assert.NotNull(state.Token);
            Assert.NotNull(state.Claims);
            Assert.Equal(_fixture.MachineToken, state.Token);
            
            // Verify correct token type detection
            Assert.Equal(TokenType.MachineToken, TokenTypeHelper.GetTokenType(_fixture.MachineToken));
            Assert.True(TokenTypeHelper.IsMachineToken(_fixture.MachineToken));
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_OAUTH_TOKEN")]
        public async Task TestRealOAuthTokenAuthentication()
        {
            // Ensure the fixture has the required tokens from environment variables
            Assert.NotNull(_fixture.SecretKey);
            Assert.NotNull(_fixture.OAuthToken);
            
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                acceptsToken: new[] { "oauth_token" }
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.OAuthToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Verify successful authentication
            Assert.False(state.IsSignedOut());
            Assert.NotNull(state.Token);
            Assert.NotNull(state.Claims);
            Assert.Equal(_fixture.OAuthToken, state.Token);
            
            // Verify correct token type detection
            Assert.Equal(TokenType.OAuthToken, TokenTypeHelper.GetTokenType(_fixture.OAuthToken));
            Assert.True(TokenTypeHelper.IsMachineToken(_fixture.OAuthToken));
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_API_KEY")]
        public async Task TestRealApiKeyAuthentication()
        {
            // Ensure the fixture has the required tokens from environment variables
            Assert.NotNull(_fixture.SecretKey);
            Assert.NotNull(_fixture.ApiKey);
            
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                acceptsToken: new[] { "api_key" }
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.ApiKey}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Verify successful authentication
            Assert.False(state.IsSignedOut());
            Assert.NotNull(state.Token);
            Assert.NotNull(state.Claims);
            Assert.Equal(_fixture.ApiKey, state.Token);
            
            // Verify correct token type detection
            Assert.Equal(TokenType.ApiKey, TokenTypeHelper.GetTokenType(_fixture.ApiKey));
            Assert.True(TokenTypeHelper.IsMachineToken(_fixture.ApiKey));
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN", "CLERK_OAUTH_TOKEN", "CLERK_API_KEY")]
        public async Task TestRealMixedTokenTypeAuthentication()
        {
            // Ensure the fixture has all required tokens from environment variables
            Assert.NotNull(_fixture.SecretKey);
            Assert.NotNull(_fixture.MachineToken);
            Assert.NotNull(_fixture.OAuthToken);
            Assert.NotNull(_fixture.ApiKey);

            // Test that the same endpoint can accept all machine token types
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                acceptsToken: new[] { "machine_token", "oauth_token", "api_key" }
            );

            var tokenTestCases = new[]
            {
                (_fixture.MachineToken, TokenType.MachineToken, "Machine Token"),
                (_fixture.OAuthToken, TokenType.OAuthToken, "OAuth Token"),
                (_fixture.ApiKey, TokenType.ApiKey, "API Key")
            };

            foreach (var (token, expectedType, tokenName) in tokenTestCases)
            {
                var httpContext = new DefaultHttpContext();
                httpContext.Request.Method = "GET";
                httpContext.Request.Host = _requestHost;
                httpContext.Request.Headers.Add("Authorization", $"Bearer {token}");

                var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

                // Verify successful authentication for each token type
                Assert.False(state.IsSignedOut(), $"{tokenName} should authenticate successfully");
                Assert.NotNull(state.Token);
                Assert.NotNull(state.Claims);
                Assert.Equal(token, state.Token);
                
                // Verify correct token type detection
                Assert.Equal(expectedType, TokenTypeHelper.GetTokenType(token));
                Assert.True(TokenTypeHelper.IsMachineToken(token), $"{tokenName} should be detected as machine token");
            }
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN")]
        public async Task TestRealMachineTokenWithSessionTokenRejection()
        {
            // Ensure the fixture has the required tokens from environment variables
            Assert.NotNull(_fixture.SecretKey);
            Assert.NotNull(_fixture.MachineToken);
            
            // Configure to only accept session tokens
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                acceptsToken: new[] { "session_token" }
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.MachineToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Should be rejected due to token type filtering
            Assert.True(state.IsSignedOut());
            Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_SESSION_TOKEN", "CLERK_MACHINE_TOKEN")]
        public async Task TestRealSessionTokenWithMachineTokenFiltering()
        {
            // Ensure the fixture has the required tokens from environment variables
            Assert.NotNull(_fixture.SecretKey);
            Assert.NotNull(_fixture.SessionToken);
            Assert.NotNull(_fixture.MachineToken);
            
            // Configure to only accept machine tokens
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                acceptsToken: new[] { "machine_token" }
            );

            // Test that session token is rejected
            var sessionContext = new DefaultHttpContext();
            sessionContext.Request.Method = "GET";
            sessionContext.Request.Host = _requestHost;
            sessionContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.SessionToken}");

            var sessionState = await AuthenticateRequest.AuthenticateRequestAsync(sessionContext.Request, arOptions);
            Assert.True(sessionState.IsSignedOut());
            Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, sessionState.ErrorReason);

            // Test that machine token is accepted
            var machineContext = new DefaultHttpContext();
            machineContext.Request.Method = "GET";
            machineContext.Request.Host = _requestHost;
            machineContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.MachineToken}");

            var machineState = await AuthenticateRequest.AuthenticateRequestAsync(machineContext.Request, arOptions);
            Assert.False(machineState.IsSignedOut());
            Assert.NotNull(machineState.Token);
            Assert.Equal(_fixture.MachineToken, machineState.Token);
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN")]
        public async Task TestRealMachineTokenClaims()
        {
            // Ensure the fixture has the required tokens from environment variables
            Assert.NotNull(_fixture.SecretKey);
            Assert.NotNull(_fixture.MachineToken);
            
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                acceptsToken: new[] { "machine_token" }
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.MachineToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Verify successful authentication
            Assert.False(state.IsSignedOut());
            Assert.NotNull(state.Claims);
            
            // Machine tokens should have specific claims structure
            var claims = state.Claims!.Claims;
            
            // Common JWT claims
            Assert.Contains(claims, c => c.Type == "iss"); // Issuer
            Assert.Contains(claims, c => c.Type == "sub"); // Subject
            Assert.Contains(claims, c => c.Type == "iat"); // Issued at
            Assert.Contains(claims, c => c.Type == "exp"); // Expiration
            
            // Machine token specific claims might include application/instance identifiers
            // The exact claims depend on how the machine token was configured in Clerk
            
            Console.WriteLine("Machine Token Claims:");
            foreach (var claim in claims)
            {
                Console.WriteLine($"CLAIM: {claim.Type} = {claim.Value}");
            }
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_API_KEY")]
        public async Task TestRealApiKeyClaims()
        {
            // Ensure the fixture has the required tokens from environment variables
            Assert.NotNull(_fixture.SecretKey);
            Assert.NotNull(_fixture.ApiKey);
            
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                acceptsToken: new[] { "api_key" }
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.ApiKey}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Verify successful authentication
            Assert.False(state.IsSignedOut());
            Assert.NotNull(state.Claims);
            
            // API keys should have specific claims structure
            var claims = state.Claims!.Claims;
            
            Console.WriteLine("API Key Claims:");
            foreach (var claim in claims)
            {
                Console.WriteLine($"CLAIM: {claim.Type} = {claim.Value}");
            }
        }

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_OAUTH_TOKEN")]
        public async Task TestRealOAuthTokenClaims()
        {
            // Ensure the fixture has the required tokens from environment variables
            Assert.NotNull(_fixture.SecretKey);
            Assert.NotNull(_fixture.OAuthToken);
            
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                acceptsToken: new[] { "oauth_token" }
            );

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {_fixture.OAuthToken}");

            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Verify successful authentication
            Assert.False(state.IsSignedOut());
            Assert.NotNull(state.Claims);
            
            // OAuth tokens should have specific claims structure
            var claims = state.Claims!.Claims;
            
            // OAuth tokens typically include scopes and client information
            Console.WriteLine("OAuth Token Claims:");
            foreach (var claim in claims)
            {
                Console.WriteLine($"CLAIM: {claim.Type} = {claim.Value}");
            }
        }

        #endregion

        #region Token Type Detection Tests

        [Theory]
        [InlineData("mt_1234567890abcdef", TokenType.MachineToken)]
        [InlineData("oat_1234567890abcdef", TokenType.OAuthToken)]
        [InlineData("ak_1234567890abcdef", TokenType.ApiKey)]
        [InlineData("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9...", TokenType.SessionToken)]
        [InlineData("", TokenType.SessionToken)]
        [InlineData("invalid_token", TokenType.SessionToken)]
        public void TestTokenTypeDetection(string token, TokenType expectedType)
        {
            var actualType = TokenTypeHelper.GetTokenType(token);
            Assert.Equal(expectedType, actualType);
        }

        [Theory]
        [InlineData("mt_1234567890abcdef", true)]
        [InlineData("oat_1234567890abcdef", true)]
        [InlineData("ak_1234567890abcdef", true)]
        [InlineData("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9...", false)]
        [InlineData("", false)]
        [InlineData("invalid_token", false)]
        public void TestMachineTokenDetection(string token, bool expectedIsMachine)
        {
            var actualIsMachine = TokenTypeHelper.IsMachineToken(token);
            Assert.Equal(expectedIsMachine, actualIsMachine);
        }

        #endregion

        #region AcceptsToken Functionality Tests

        [Fact]
        public async Task TestAcceptsTokenDefaults()
        {
            // When no acceptsToken is specified, should default to ["any"]
            var arOptions = new AuthenticateRequestOptions(secretKey: "sk_test_secret");
            
            Assert.Contains("any", arOptions.AcceptsToken);
        }

        [Fact]
        public async Task TestAcceptsAnyTokenType()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "any" }
            );

            var tokenTestCases = new[]
            {
                "mt_machine_token_123",
                "oat_oauth_token_123", 
                "ak_api_key_123",
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.session_token"
            };

            foreach (var token in tokenTestCases)
            {
                var httpContext = CreateHttpContextWithToken(token);
                var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

                // Should not be rejected due to token type (will fail verification due to test setup)
                Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
            }
        }

        [Fact]
        public async Task TestOnlySessionTokensAccepted()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "session_token" }
            );

            // Session token should be accepted
            var sessionContext = CreateHttpContextWithToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.session");
            var sessionState = await AuthenticateRequest.AuthenticateRequestAsync(sessionContext.Request, arOptions);
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, sessionState.ErrorReason);

            // Machine tokens should be rejected
            var machineTokens = new[] { "mt_test", "oat_test", "ak_test" };
            foreach (var token in machineTokens)
            {
                var context = CreateHttpContextWithToken(token);
                var state = await AuthenticateRequest.AuthenticateRequestAsync(context.Request, arOptions);
                Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
            }
        }

        [Fact]
        public async Task TestOnlyMachineTokensAccepted()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "machine_token", "oauth_token", "api_key" }
            );

            // Machine tokens should be accepted
            var machineTokens = new[] { "mt_test", "oat_test", "ak_test" };
            foreach (var token in machineTokens)
            {
                var context = CreateHttpContextWithToken(token);
                var state = await AuthenticateRequest.AuthenticateRequestAsync(context.Request, arOptions);
                Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
            }

            // Session token should be rejected
            var sessionContext = CreateHttpContextWithToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.session");
            var sessionState = await AuthenticateRequest.AuthenticateRequestAsync(sessionContext.Request, arOptions);
            Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, sessionState.ErrorReason);
        }

        [Theory]
        [InlineData("mt_test_token", new[] { "machine_token" }, false)] // Should be accepted
        [InlineData("oat_test_token", new[] { "oauth_token" }, false)] // Should be accepted
        [InlineData("ak_test_token", new[] { "api_key" }, false)] // Should be accepted
        [InlineData("mt_test_token", new[] { "session_token" }, true)] // Should be rejected
        [InlineData("session_jwt_token", new[] { "machine_token" }, true)] // Should be rejected
        [InlineData("oat_test_token", new[] { "machine_token", "api_key" }, true)] // Should be rejected (oauth not in list)
        [InlineData("ak_test_token", new[] { "session_token", "oauth_token" }, true)] // Should be rejected (api_key not in list)
        public async Task TestSpecificTokenTypeFiltering(string token, string[] acceptedTypes, bool shouldBeRejected)
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: acceptedTypes
            );

            var httpContext = CreateHttpContextWithToken(token);
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            if (shouldBeRejected)
            {
                Assert.True(state.IsSignedOut());
                Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
            }
            else
            {
                // Token type is accepted, but verification might still fail
                Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
            }
        }

        #endregion

        #region Machine Token Specific Tests

        [Fact]
        public async Task TestMachineTokenRequiresSecretKey()
        {
            // Machine tokens should not work with only JWT key
            var arOptions = new AuthenticateRequestOptions(
                jwtKey: "test-jwt-key", // Only JWT key, no secret key
                acceptsToken: new[] { "any" }
            );

            var httpContext = CreateHttpContextWithToken("mt_test_token");
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            Assert.True(state.IsSignedOut());
            Assert.Equal(AuthErrorReason.SECRET_KEY_MISSING, state.ErrorReason);
        }

        [Fact]
        public async Task TestMachineTokenWithSecretKey()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "any" }
            );

            var httpContext = CreateHttpContextWithToken("mt_test_token");
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Should attempt verification (will fail due to no real HTTP client, but won't fail on secret key)
            Assert.NotEqual(AuthErrorReason.SECRET_KEY_MISSING, state.ErrorReason);
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
        }

        [Theory]
        [InlineData("mt_machine_token_123")]
        [InlineData("oat_oauth_token_123")]
        [InlineData("ak_api_key_123")]
        public async Task TestDifferentMachineTokenPrefixes(string token)
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "any" }
            );

            var httpContext = CreateHttpContextWithToken(token);
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // All should be recognized as machine tokens and require secret key verification
            Assert.NotEqual(AuthErrorReason.SECRET_KEY_MISSING, state.ErrorReason);
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
        }

        #endregion
       
        #region Error Handling Tests

        [Fact]
        public void TestTokenTypeNotSupportedError()
        {
            var exception = new AuthenticateRequestException(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED);
            Assert.Equal("token-type-not-supported", exception.Reason.Id);
            Assert.Contains("not supported", exception.Reason.Message);
            Assert.Contains("session_token, machine_token, oauth_token, or api_key", exception.Reason.Message);
        }

        [Fact]
        public async Task TestEmptyAcceptsTokenArray()
        {
            // Edge case: empty acceptsToken array should reject all tokens
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new string[0]
            );

            var httpContext = CreateHttpContextWithToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.session");
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
        }

        [Fact]
        public async Task TestInvalidTokenTypeInAcceptsToken()
        {
            // Invalid token type in acceptsToken array should not cause errors, just won't match
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "invalid_token_type", "session_token" }
            );

            var httpContext = CreateHttpContextWithToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.session");
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Should still accept session_token despite invalid type in array
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
        }

        #endregion

        #region Helper Methods

        private DefaultHttpContext CreateHttpContextWithToken(string token)
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = _requestHost;
            httpContext.Request.Headers.Add("Authorization", $"Bearer {token}");
            return httpContext;
        }

        #endregion
    }
}
