#nullable enable
using Clerk.BackendAPI.Helpers.Jwks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace JwksHelpers.Tests
{
    /// <summary>
    /// Real integration tests for M2M authentication using actual Clerk API calls.
    /// These tests require real credentials and make actual HTTP requests to Clerk's API.
    /// </summary>
    public class M2MAuthIntegrationTests : IClassFixture<JwksHelpersFixture>
    {
        private readonly JwksHelpersFixture _fixture;

        public M2MAuthIntegrationTests(JwksHelpersFixture fixture)
        {
            _fixture = fixture;
        }

        #region Machine Token Real Verification Tests

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN")]
        public async Task TestRealMachineTokenVerification()
        {
            // Arrange
            var options = new VerifyTokenOptions(secretKey: _fixture.SecretKey!);

            // Act & Assert
            var claims = await VerifyToken.VerifyTokenAsync(_fixture.MachineToken!, options);

            // Verify claims structure
            Assert.NotNull(claims);
            Assert.NotEmpty(claims.Claims);
            
            // Common M2M token claims
            var subjectClaim = claims.FindFirst("sub");
            Assert.NotNull(subjectClaim);
            Assert.NotEmpty(subjectClaim.Value);

            var issuedAtClaim = claims.FindFirst("iat");
            Assert.NotNull(issuedAtClaim);

            var expirationClaim = claims.FindFirst("exp");
            Assert.NotNull(expirationClaim);

            Console.WriteLine($"Machine token verified successfully. Subject: {subjectClaim.Value}");
        }

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_OAUTH_TOKEN")]
        public async Task TestRealOAuthTokenVerification()
        {
            // Arrange
            var options = new VerifyTokenOptions(secretKey: _fixture.SecretKey!);

            // Act & Assert
            var claims = await VerifyToken.VerifyTokenAsync(_fixture.OAuthToken!, options);

            // Verify claims structure
            Assert.NotNull(claims);
            Assert.NotEmpty(claims.Claims);
            
            var subjectClaim = claims.FindFirst("sub");
            Assert.NotNull(subjectClaim);
            
            Console.WriteLine($"OAuth token verified successfully. Subject: {subjectClaim.Value}");
        }

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_API_KEY")]
        public async Task TestRealApiKeyVerification()
        {
            // Arrange
            var options = new VerifyTokenOptions(secretKey: _fixture.SecretKey!);

            // Act & Assert
            var claims = await VerifyToken.VerifyTokenAsync(_fixture.ApiKey!, options);

            // Verify claims structure
            Assert.NotNull(claims);
            Assert.NotEmpty(claims.Claims);
            
            var subjectClaim = claims.FindFirst("sub");
            Assert.NotNull(subjectClaim);
            
            Console.WriteLine($"API key verified successfully. Subject: {subjectClaim.Value}");
        }

        #endregion

        #region Real Authentication Request Tests

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN")]
        public async Task TestRealAuthenticateRequest_MachineToken()
        {
            // Arrange
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "machine_token" }
            );

            var httpContext = CreateHttpContextWithToken(_fixture.MachineToken!);

            // Act
            var requestState = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, options);

            // Assert
            Assert.True(requestState.IsSignedIn());
            Assert.NotNull(requestState.Claims);
            Assert.Equal(_fixture.MachineToken, requestState.Token);

            var userId = GetUserIdFromClaims(requestState.Claims);
            Assert.NotNull(userId);
            Assert.NotEmpty(userId);

            Console.WriteLine($"Machine token authentication successful. User ID: {userId}");
        }

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_OAUTH_TOKEN")]
        public async Task TestRealAuthenticateRequest_OAuthToken()
        {
            // Arrange
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "oauth_token" }
            );

            var httpContext = CreateHttpContextWithToken(_fixture.OAuthToken!);

            // Act
            var requestState = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, options);

            // Assert
            Assert.True(requestState.IsSignedIn());
            Assert.NotNull(requestState.Claims);
            Assert.Equal(_fixture.OAuthToken, requestState.Token);

            var userId = GetUserIdFromClaims(requestState.Claims);
            Assert.NotNull(userId);

            Console.WriteLine($"OAuth token authentication successful. User ID: {userId}");
        }

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_API_KEY")]
        public async Task TestRealAuthenticateRequest_ApiKey()
        {
            // Arrange
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "api_key" }
            );

            var httpContext = CreateHttpContextWithToken(_fixture.ApiKey!);

            // Act
            var requestState = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, options);

            // Assert
            Assert.True(requestState.IsSignedIn());
            Assert.NotNull(requestState.Claims);
            Assert.Equal(_fixture.ApiKey, requestState.Token);

            var userId = GetUserIdFromClaims(requestState.Claims);
            Assert.NotNull(userId);

            Console.WriteLine($"API key authentication successful. User ID: {userId}");
        }

        #endregion

        #region Mixed Token Type Tests

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN", "CLERK_OAUTH_TOKEN", "CLERK_API_KEY")]
        public async Task TestRealMixedTokenAuthentication()
        {
            // Test that an endpoint can accept multiple token types
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "machine_token", "oauth_token", "api_key" }
            );

            var tokens = new[]
            {
                ("machine_token", _fixture.MachineToken!),
                ("oauth_token", _fixture.OAuthToken!),
                ("api_key", _fixture.ApiKey!)
            };

            foreach (var (tokenTypeName, token) in tokens)
            {
                var httpContext = CreateHttpContextWithToken(token);
                var requestState = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, options);

                Assert.True(requestState.IsSignedIn(), $"{tokenTypeName} should be authenticated");
                Assert.NotNull(requestState.Claims);
                Assert.Equal(token, requestState.Token);

                var userId = GetUserIdFromClaims(requestState.Claims);
                Assert.NotNull(userId);

                Console.WriteLine($"{tokenTypeName} authentication successful. User ID: {userId}");
            }
        }

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN", "CLERK_SESSION_TOKEN")]
        public async Task TestRealHybridSessionAndMachineAuthentication()
        {
            if (string.IsNullOrEmpty(_fixture.SessionToken))
            {
                // Skip if no session token is available
                return;
            }

            // Test that an endpoint can accept both session and machine tokens
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "session_token", "machine_token" }
            );

            // Test machine token
            var machineContext = CreateHttpContextWithToken(_fixture.MachineToken!);
            var machineState = await AuthenticateRequest.AuthenticateRequestAsync(machineContext.Request, options);

            Assert.True(machineState.IsSignedIn(), "Machine token should be authenticated");
            var machineUserId = GetUserIdFromClaims(machineState.Claims!);
            Console.WriteLine($"Machine token in hybrid mode successful. User ID: {machineUserId}");

            // Test session token (if not expired)
            var sessionContext = CreateHttpContextWithToken(_fixture.SessionToken);
            var sessionState = await AuthenticateRequest.AuthenticateRequestAsync(sessionContext.Request, options);

            if (sessionState.IsSignedIn())
            {
                var sessionUserId = GetUserIdFromClaims(sessionState.Claims!);
                Console.WriteLine($"Session token in hybrid mode successful. User ID: {sessionUserId}");
            }
            else if (sessionState.ErrorReason == TokenVerificationErrorReason.TOKEN_EXPIRED)
            {
                Console.WriteLine("Session token is expired, which is expected for test tokens.");
            }
            else
            {
                // Fail only if it's not an expiration issue
                Assert.Fail($"Session token failed for unexpected reason: {sessionState.ErrorReason}");
            }
        }

        #endregion

        #region Token Type Filtering Tests

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN")]
        public async Task TestRealTokenTypeFiltering_RejectWrongType()
        {
            // Configure to only accept session tokens
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "session_token" }
            );

            // Try to authenticate with machine token - should be rejected
            var httpContext = CreateHttpContextWithToken(_fixture.MachineToken!);
            var requestState = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, options);

            Assert.True(requestState.IsSignedOut());
            Assert.Equal(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED, requestState.ErrorReason);

            Console.WriteLine("Token type filtering working correctly - machine token rejected when only session tokens are accepted.");
        }

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN", "CLERK_OAUTH_TOKEN", "CLERK_API_KEY")]
        public async Task TestRealSpecificTokenTypeAcceptance()
        {
            var testCases = new[]
            {
                ("machine_token", _fixture.MachineToken!),
                ("oauth_token", _fixture.OAuthToken!),
                ("api_key", _fixture.ApiKey!)
            };

            foreach (var (tokenType, token) in testCases)
            {
                // Configure to accept only this specific token type
                var options = new AuthenticateRequestOptions(
                    secretKey: _fixture.SecretKey!,
                    acceptsToken: new[] { tokenType }
                );

                var httpContext = CreateHttpContextWithToken(token);
                var requestState = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, options);

                Assert.True(requestState.IsSignedIn(), $"{tokenType} should be accepted when specifically configured");
                
                Console.WriteLine($"Specific token type acceptance test passed for {tokenType}");
            }
        }

        #endregion

        #region Error Handling Tests

        [RealIntegrationFact("CLERK_SECRET_KEY")]
        public async Task TestRealInvalidTokenHandling()
        {
            var options = new VerifyTokenOptions(secretKey: _fixture.SecretKey!);
            
            // Test with invalid machine token
            var invalidToken = "mt_invalid_token_12345";
            
            var exception = await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(invalidToken, options)
            );

            Assert.NotNull(exception.Reason);
            Console.WriteLine($"Invalid token correctly rejected with reason: {exception.Reason.Id}");
        }

        [RealIntegrationFact("CLERK_MACHINE_TOKEN")]
        public async Task TestRealMissingSecretKeyHandling()
        {
            var options = new VerifyTokenOptions(secretKey: null);
            
            // Test without secret key
            await Assert.ThrowsAsync<TokenVerificationException>(
                () => VerifyToken.VerifyTokenAsync(_fixture.MachineToken!, options)
            );

            Console.WriteLine("Missing secret key correctly handled with TokenVerificationException");
        }

        #endregion

        #region Performance Tests

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN")]
        public async Task TestRealTokenVerificationPerformance()
        {
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "machine_token" }
            );

            var iterations = 5;
            var httpContext = CreateHttpContextWithToken(_fixture.MachineToken!);

            var startTime = DateTime.UtcNow;

            for (int i = 0; i < iterations; i++)
            {
                var requestState = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, options);
                Assert.True(requestState.IsSignedIn());
            }

            var endTime = DateTime.UtcNow;
            var totalTime = endTime - startTime;
            var avgTime = totalTime.TotalMilliseconds / iterations;

            Console.WriteLine($"Average token verification time over {iterations} iterations: {avgTime:F2}ms");
            
            // Performance assertion - should complete within reasonable time
            Assert.True(avgTime < 2000, $"Token verification took too long: {avgTime}ms");
        }

        #endregion

        #region Helper Methods

        private DefaultHttpContext CreateHttpContextWithToken(string token)
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = new HostString(_fixture.RequestHost);
            httpContext.Request.Headers["Authorization"] = $"Bearer {token}";
            return httpContext;
        }

        private string? GetUserIdFromClaims(ClaimsPrincipal claims)
        {
            // Try different claim types that might contain user ID
            return claims.FindFirst("sub")?.Value ?? 
                   claims.FindFirst("user_id")?.Value ??
                   claims.FindFirst("id")?.Value;
        }

        #endregion
    }

    #region Real-World Scenario Tests

    /// <summary>
    /// Tests that simulate real-world M2M authentication scenarios
    /// </summary>
    public class M2MRealWorldScenarioTests : IClassFixture<JwksHelpersFixture>
    {
        private readonly JwksHelpersFixture _fixture;

        public M2MRealWorldScenarioTests(JwksHelpersFixture fixture)
        {
            _fixture = fixture;
        }

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN")]
        public async Task TestApiGatewayScenario()
        {
            // Scenario: API Gateway that accepts both user sessions and M2M tokens
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "any" } // Accept any token type
            );

            // Test with M2M token
            var httpContext = CreateHttpContextWithToken(_fixture.MachineToken!);
            var requestState = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, options);

            Assert.True(requestState.IsSignedIn());
            var userId = GetUserIdFromClaims(requestState.Claims!);
            Console.WriteLine($"API Gateway scenario successful with machine token. User ID: {userId}");
        }

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_MACHINE_TOKEN")]
        public async Task TestMicroserviceToMicroserviceScenario()
        {
            // Scenario: Internal microservice that only accepts M2M tokens
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "machine_token" }
            );

            var httpContext = CreateHttpContextWithToken(_fixture.MachineToken!);
            var requestState = await AuthenticateRequest.AuthenticateRequestAsync(httpContext.Request, options);

            Assert.True(requestState.IsSignedIn());
            var userId = GetUserIdFromClaims(requestState.Claims!);
            Console.WriteLine($"Microservice-to-microservice scenario successful. User ID: {userId}");
        }

        [RealIntegrationFact("CLERK_SECRET_KEY", "CLERK_OAUTH_TOKEN", "CLERK_API_KEY")]
        public async Task TestResourceServerScenario()
        {
            // Scenario: OAuth resource server that accepts OAuth tokens and API keys
            var options = new AuthenticateRequestOptions(
                secretKey: _fixture.SecretKey!,
                acceptsToken: new[] { "oauth_token", "api_key" }
            );

            // Test OAuth token
            var oauthContext = CreateHttpContextWithToken(_fixture.OAuthToken!);
            var oauthState = await AuthenticateRequest.AuthenticateRequestAsync(oauthContext.Request, options);
            Assert.True(oauthState.IsSignedIn());

            // Test API key
            var apiKeyContext = CreateHttpContextWithToken(_fixture.ApiKey!);
            var apiKeyState = await AuthenticateRequest.AuthenticateRequestAsync(apiKeyContext.Request, options);
            Assert.True(apiKeyState.IsSignedIn());

            Console.WriteLine("Resource server scenario successful with both OAuth token and API key");
        }

        private DefaultHttpContext CreateHttpContextWithToken(string token)
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "GET";
            httpContext.Request.Host = new HostString(_fixture.RequestHost);
            httpContext.Request.Headers["Authorization"] = $"Bearer {token}";
            return httpContext;
        }

        private string? GetUserIdFromClaims(ClaimsPrincipal claims)
        {
            // Try different claim types that might contain user ID
            return claims.FindFirst("sub")?.Value ?? 
                   claims.FindFirst("user_id")?.Value ??
                   claims.FindFirst("id")?.Value;
        }
    }

    #endregion
} 