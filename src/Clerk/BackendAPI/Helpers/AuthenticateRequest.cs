using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace Clerk.BackendAPI.Helpers.Jwks;

/// <summary>
///     AuthenticateRequest - Helper methods to authenticate requests.
/// </summary>
public static class AuthenticateRequest
{
    private const string SESSION_COOKIE_PREFIX = "__session";

    /// <summary>
    ///     Checks if the HTTP request is authenticated.
    ///     First the session token is retrieved from either the __session cookie
    ///     or the HTTP Authorization header.
    ///     Then the session token is verified: networklessly if the options.jwtKey
    ///     is provided, otherwise by fetching the JWKS from Clerk's Backend API.
    /// </summary>
    /// <param name="request">The HTTP request</param>
    /// <param name="options">The request authentication options</param>
    /// <returns>The request state</returns>
    /// <remarks>WARNING: AuthenticateRequestAsync is applicable in the context of Backend APIs only.</remarks>
    public static async Task<RequestState> AuthenticateRequestAsync(
        HttpRequest request,
        AuthenticateRequestOptions options)
    {
        var sessionToken = GetSessionToken(request);
        if (sessionToken == null) return RequestState.SignedOut(AuthErrorReason.SESSION_TOKEN_MISSING);

        var tokenType = TokenTypeHelper.GetTokenType(sessionToken);
        var tokenTypeName = tokenType switch
        {
            TokenType.SessionToken => "session_token",
            TokenType.MachineToken => "machine_token",
            TokenType.MachineTokenV2 => "m2m_token",
            TokenType.OAuthToken => "oauth_token",
            TokenType.ApiKey => "api_key",
            _ => tokenType.ToString().ToLowerInvariant()
        };

        // Check if token type is accepted
        if (!options.AcceptsToken.Contains("any") && !options.AcceptsToken.Contains(tokenTypeName))
        {
            // Special case: if acceptsToken contains "machine_token", accept both MachineToken and MachineTokenV2
            bool isAccepted = false;
            if (options.AcceptsToken.Contains("machine_token") &&
                (tokenType == TokenType.MachineToken || tokenType == TokenType.MachineTokenV2))
            {
                isAccepted = true;
            }

            if (!isAccepted)
            {
                return RequestState.SignedOut(AuthErrorReason.TOKEN_TYPE_NOT_SUPPORTED);
            }
        }

        VerifyTokenOptions verifyTokenOptions;

        if (TokenTypeHelper.IsMachineToken(sessionToken))
        {
            if (options.SecretKey == null && options.MachineSecretKey == null)
                return RequestState.SignedOut(AuthErrorReason.SECRET_KEY_MISSING);

            verifyTokenOptions = new VerifyTokenOptions(
                secretKey: options.SecretKey,
                machineSecretKey: options.MachineSecretKey,
                skipJwksCache: options.SkipJwksCache
            );
        }
        else
        {
            // Session tokens can use either JWT key or secret key
            if (options.JwtKey != null)
                verifyTokenOptions = new VerifyTokenOptions(
                    jwtKey: options.JwtKey,
                    audiences: options.Audiences,
                    authorizedParties: options.AuthorizedParties,
                    clockSkewInMs: options.ClockSkewInMs,
                    skipJwksCache: options.SkipJwksCache
                );
            else if (options.SecretKey != null)
                verifyTokenOptions = new VerifyTokenOptions(
                    options.SecretKey,
                    audiences: options.Audiences,
                    authorizedParties: options.AuthorizedParties,
                    clockSkewInMs: options.ClockSkewInMs,
                    skipJwksCache: options.SkipJwksCache
                );
            else
                return RequestState.SignedOut(AuthErrorReason.SECRET_KEY_MISSING);
        }

        try
        {
            var claims = await VerifyToken.VerifyTokenAsync(sessionToken, verifyTokenOptions);
            return RequestState.SignedIn(sessionToken, claims);
        }
        catch (TokenVerificationException e)
        {
            return RequestState.SignedOut(e.Reason);
        }
    }

    /// <summary>
    ///     Retrieve token from __session cookie or Authorization header.
    /// </summary>
    /// <param name="request">The HTTP request</param>
    /// <returns>The session token, if present</returns>
    private static string? GetSessionToken(HttpRequest request)
    {
        var authorizationHeaders = request.Headers.GetCommaSeparatedValues("Authorization");
        if (authorizationHeaders != StringValues.Empty)
        {
            var bearerToken = authorizationHeaders.FirstOrDefault();
            if (!string.IsNullOrEmpty(bearerToken)) return bearerToken.Replace("Bearer ", "");
        }
        var cookieHeaders = request.Headers.GetCommaSeparatedValues("Cookie");
        if (cookieHeaders != StringValues.Empty)
        {
            var cookieHeaderValue = cookieHeaders.FirstOrDefault();
            if (!string.IsNullOrEmpty(cookieHeaderValue))
            {
                var cookies = cookieHeaderValue.Split(';')
                    .Select(cookie => cookie.Trim())
                    .Select(cookie => new Cookie(cookie.Split('=')[0], cookie.Split('=')[1]));

                foreach (var cookie in cookies)
                    if (cookie.Name.StartsWith(SESSION_COOKIE_PREFIX))
                        return cookie.Value;
            }
        }

        return null;
    }
}