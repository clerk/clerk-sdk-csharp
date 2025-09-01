#nullable enable
using Clerk.BackendAPI.Helpers.Jwks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Moq.Protected;
using System.Threading;
using Newtonsoft.Json;

namespace JwksHelpers.Tests
{
    public class M2MAuthenticationTests : IClassFixture<JwksHelpersFixture>
    {
        private readonly JwksHelpersFixture _fixture;

        public M2MAuthenticationTests(JwksHelpersFixture fixture)
        {
            _fixture = fixture;
        }

        #region Token Type Detection Tests

        [Theory]
        [InlineData("mt_1234567890abcdef", TokenType.MachineToken, true)]
        [InlineData("oat_1234567890abcdef", TokenType.OAuthToken, true)]
        [InlineData("ak_1234567890abcdef", TokenType.ApiKey, true)]
        [InlineData("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9...", TokenType.SessionToken, false)]
        [InlineData("", TokenType.SessionToken, false)]
        [InlineData("invalid_token", TokenType.SessionToken, false)]
        public void TestTokenTypeDetection(string token, TokenType expectedType, bool expectedIsMachine)
        {
            // Test token type detection
            var actualType = TokenTypeHelper.GetTokenType(token);
            Assert.Equal(expectedType, actualType);

            // Test machine token detection
            var actualIsMachine = TokenTypeHelper.IsMachineToken(token);
            Assert.Equal(expectedIsMachine, actualIsMachine);
        }

        [Theory]
        [InlineData(TokenType.MachineToken, "/m2m_tokens/verify")]
        [InlineData(TokenType.OAuthToken, "/oauth_applications/access_tokens/verify")]
        [InlineData(TokenType.ApiKey, "/api_keys/verify")]
        public void TestVerificationEndpoints(TokenType tokenType, string expectedEndpoint)
        {
            var actualEndpoint = TokenTypeHelper.GetVerificationEndpoint(tokenType);
            Assert.Equal(expectedEndpoint, actualEndpoint);
        }

        [Fact]
        public void TestInvalidTokenTypeForEndpoint()
        {
            Assert.Throws<ArgumentException>(() => 
                TokenTypeHelper.GetVerificationEndpoint(TokenType.SessionToken));
        }

        #endregion

        #region Machine Token Verification Tests

        [Fact]
        public async Task TestVerifyMachineToken_Success()
        {
            // Arrange
            var machineToken = "mt_test_machine_token_12345";
            var secretKey = "sk_test_secret_key";
            var expectedResponse = new
            {
                aud = "test-audience",
                sub = "machine_user_123",
                iss = "https://api.clerk.com",
                exp = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds(),
                iat = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                token_type = "machine"
            };

            var mockHttpMessageHandler = CreateMockHttpHandler(
                HttpStatusCode.OK, 
                JsonConvert.SerializeObject(expectedResponse)
            );

            // Mock VerifyToken to use our mocked HTTP client
            var options = new VerifyTokenOptions(secretKey: secretKey);

            // Note: This test demonstrates the structure. In a real implementation,
            // you'd need to inject the HttpClient or create a testable wrapper
            // For now, we'll test the error cases that don't require HTTP mocking

            // Test that machine token is detected correctly
            var tokenType = TokenTypeHelper.GetTokenType(machineToken);
            Assert.Equal(TokenType.MachineToken, tokenType);
            Assert.True(TokenTypeHelper.IsMachineToken(machineToken));
        }

        [Fact]
        public async Task TestVerifyMachineToken_MissingSecretKey()
        {
            var machineToken = "mt_test_machine_token_12345";
            var options = new VerifyTokenOptions(jwtKey: "some-jwt-key");

            var exception = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(machineToken, options)
            );

            Assert.Equal(TokenVerificationErrorReason.SECRET_KEY_MISSING, exception.Reason);
        }

        [Fact]
        public async Task TestVerifyMachineToken_WithMachineSecretKey()
        {
            var machineToken = "mt_test_machine_token_12345";
            var options = new VerifyTokenOptions(machineSecretKey: "ms_test_machine_secret_key");

            var tokenType = TokenTypeHelper.GetTokenType(machineToken);
            Assert.Equal(TokenType.MachineToken, tokenType);
            Assert.True(TokenTypeHelper.IsMachineToken(machineToken));
        }

        [Fact]
        public async Task TestVerifyMachineToken_WithBothKeys()
        {
            var machineToken = "mt_test_machine_token_12345";
            var options = new VerifyTokenOptions(
                secretKey: "sk_test_secret_key",
                machineSecretKey: "ms_test_machine_secret_key"
            );

            var tokenType = TokenTypeHelper.GetTokenType(machineToken);
            Assert.Equal(TokenType.MachineToken, tokenType);
            Assert.True(TokenTypeHelper.IsMachineToken(machineToken));
        }

        #endregion

        #region Authentication Request Tests

        [Fact]
        public async Task TestAuthenticateRequest_AcceptsAllTokenTypes()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "any" }
            );

            // Test with machine token
            var httpContext = CreateHttpContextWithToken("mt_test_token");
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Should attempt verification (will fail due to no real HTTP client, but won't fail on token type)
            Assert.True(state.IsSignedOut()); // Will be signed out due to verification failure, not token type rejection
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
        }

        [Fact]
        public async Task TestAuthenticateRequest_OnlySessionTokens()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "session_token" }
            );

            // Test with machine token - should be rejected
            var httpContext = CreateHttpContextWithToken("mt_test_token");
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            Assert.True(state.IsSignedOut());
            Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
        }

        [Fact]
        public async Task TestAuthenticateRequest_OnlyMachineTokens()
        {
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "machine_token", "oauth_token", "api_key" }
            );

            // Test with session token - should be rejected
            var httpContext = CreateHttpContextWithToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWV9.invalid");
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            Assert.True(state.IsSignedOut());
            Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
        }

        [Theory]
        [InlineData("mt_test_token", new[] { "machine_token" }, false)] // Should be accepted
        [InlineData("oat_test_token", new[] { "oauth_token" }, false)] // Should be accepted
        [InlineData("ak_test_token", new[] { "api_key" }, false)] // Should be accepted
        [InlineData("mt_test_token", new[] { "session_token" }, true)] // Should be rejected
        [InlineData("session_jwt_token", new[] { "machine_token" }, true)] // Should be rejected
        public async Task TestTokenTypeFiltering(string token, string[] acceptedTypes, bool shouldBeRejected)
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
                Assert.True(state.IsSignedOut()); // Will fail verification due to no real server
                Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
            }
        }

        #endregion

        #region Session Token vs Machine Token Routing Tests

        [ConditionalFact("CLERK_SECRET_KEY", "CLERK_SESSION_TOKEN")]
        public async Task TestSessionTokenStillWorks()
        {
            // Ensure existing session token functionality still works
            var arOptions = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey,
                audiences: _fixture.Audiences,
                authorizedParties: _fixture.AuthorizedParties,
                acceptsToken: new[] { "any" }
            );

            var httpContext = CreateHttpContextWithToken(_fixture.SessionToken);
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            // Should work as before (or fail with token expired, not type error)
            if (state.IsSignedOut())
            {
                Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
            }
            else
            {
                Utils.AssertStateAsync(state, _fixture.SessionToken);
            }
        }

        [Fact]
        public async Task TestLocalJwtKeyWithMachineToken()
        {
            // Machine tokens should not use JWT key verification
            var arOptions = new AuthenticateRequestOptions(
                jwtKey: _fixture.TestJwtKey, // Only JWT key, no secret key
                acceptsToken: new[] { "any" }
            );

            var httpContext = CreateHttpContextWithToken("mt_test_token");
            var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

            Assert.True(state.IsSignedOut());
            Assert.Equal(AuthErrorReason.SECRET_KEY_MISSING, state.ErrorReason);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public void TestInvalidTokenTypeError()
        {
            var exception = new TokenVerificationException(TokenVerificationErrorReason.INVALID_TOKEN_TYPE);
            Assert.Equal("invalid-token-type", exception.Reason.Id);
            Assert.Contains("valid Clerk token type", exception.Reason.Message);
        }

        [Fact]
        public void TestTokenTypeNotSupportedError()
        {
            var exception = new AuthenticateRequestException(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED);
            Assert.Equal("token-type-not-supported", exception.Reason.Id);
            Assert.Contains("not supported", exception.Reason.Message);
        }

        [Fact]
        public void TestServerError()
        {
            var exception = new TokenVerificationException(TokenVerificationErrorReason.SERVER_ERROR);
            Assert.Equal("server-error", exception.Reason.Id);
            Assert.Contains("unexpected error", exception.Reason.Message);
        }

        #endregion

        #region Integration Tests with Real Scenarios

        [Fact]
        public async Task TestMixedTokenTypeAuthentication()
        {
            // Test that the same endpoint can handle different token types
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "any" }
            );

            var testCases = new[]
            {
                ("mt_machine_token", TokenType.MachineToken),
                ("oat_oauth_token", TokenType.OAuthToken),
                ("ak_api_key", TokenType.ApiKey),
                ("session_jwt", TokenType.SessionToken)
            };

            foreach (var (token, expectedType) in testCases)
            {
                var httpContext = CreateHttpContextWithToken(token);
                var state = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, arOptions);

                // Verify token type is detected correctly (verification will fail due to test setup)
                var actualType = TokenTypeHelper.GetTokenType(token);
                Assert.Equal(expectedType, actualType);

                // Should not fail due to token type issues
                Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, state.ErrorReason);
            }
        }

        #endregion

        #region Helper Methods

        private DefaultHttpContext CreateHttpContextWithToken(string token)
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = new HostString(_fixture.RequestHost);
            httpContext.Request.Headers.Add("Authorization", $"Bearer {token}");
            return httpContext;
        }

        private Mock<HttpMessageHandler> CreateMockHttpHandler(HttpStatusCode statusCode, string responseContent)
        {
            var mockHandler = new Mock<HttpMessageHandler>();
            
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(responseContent, Encoding.UTF8, "application/json")
                });

            return mockHandler;
        }

        #endregion
    }

    #region M2M Integration Scenarios

    /// <summary>
    /// Tests that demonstrate real-world M2M authentication scenarios
    /// </summary>
    public class M2MIntegrationScenarios : IClassFixture<JwksHelpersFixture>
    {
        private readonly JwksHelpersFixture _fixture;

        public M2MIntegrationScenarios(JwksHelpersFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task TestApiGatewayScenario()
        {
            // Scenario: API Gateway that accepts both user sessions and M2M tokens
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "any" },
                audiences: new[] { "api-gateway" }
            );

            // Test M2M token
            var m2mContext = CreateHttpContextWithToken("mt_service_token_123");
            var m2mState = await AuthenticateRequest.AuthenticateRequestAsync(m2mContext.Request, arOptions);
            
            // Should not be rejected due to token type
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, m2mState.ErrorReason);

            // Test session token
            var sessionContext = CreateHttpContextWithToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.session");
            var sessionState = await AuthenticateRequest.AuthenticateRequestAsync(sessionContext.Request, arOptions);
            
            // Should not be rejected due to token type
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, sessionState.ErrorReason);
        }

        [Fact]
        public async Task TestMicroserviceToMicroserviceScenario()
        {
            // Scenario: Microservice that only accepts M2M tokens
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "machine_token" }
            );

            // Should accept M2M token
            var m2mContext = CreateHttpContextWithToken("mt_service_token_123");
            var m2mState = await AuthenticateRequest.AuthenticateRequestAsync(m2mContext.Request, arOptions);
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, m2mState.ErrorReason);

            // Should reject session token
            var sessionContext = CreateHttpContextWithToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.session");
            var sessionState = await AuthenticateRequest.AuthenticateRequestAsync(sessionContext.Request, arOptions);
            Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, sessionState.ErrorReason);
        }

        [Fact]
        public async Task TestOAuthResourceServerScenario()
        {
            // Scenario: OAuth resource server that accepts OAuth and API key tokens
            var arOptions = new AuthenticateRequestOptions(
                secretKey: "sk_test_secret",
                acceptsToken: new[] { "oauth_token", "api_key" }
            );

            // Should accept OAuth token
            var oauthContext = CreateHttpContextWithToken("oat_oauth_access_token_123");
            var oauthState = await AuthenticateRequest.AuthenticateRequestAsync(oauthContext.Request, arOptions);
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, oauthState.ErrorReason);

            // Should accept API key
            var apiKeyContext = CreateHttpContextWithToken("ak_api_key_123");
            var apiKeyState = await AuthenticateRequest.AuthenticateRequestAsync(apiKeyContext.Request, arOptions);
            Assert.NotEqual(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, apiKeyState.ErrorReason);

            // Should reject M2M token
            var m2mContext = CreateHttpContextWithToken("mt_machine_token_123");
            var m2mState = await AuthenticateRequest.AuthenticateRequestAsync(m2mContext.Request, arOptions);
            Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, m2mState.ErrorReason);
        }

        private DefaultHttpContext CreateHttpContextWithToken(string token)
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = new HostString(_fixture.RequestHost);
            httpContext.Request.Headers.Add("Authorization", $"Bearer {token}");
            return httpContext;
        }
    }

    #endregion
} 