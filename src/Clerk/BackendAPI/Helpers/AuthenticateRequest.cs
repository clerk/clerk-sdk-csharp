using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Clerk.BackendAPI.Helpers.Jwks;

/// <summary>
///     AuthenticateRequest - Helper methods to authenticate requests.
/// </summary>
public static class AuthenticateRequest
{
    private const string SESSION_COOKIE_NAME = "__session";

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
        HttpRequestMessage request,
        AuthenticateRequestOptions options)
    {
        var sessionToken = GetSessionToken(request);
        if (sessionToken == null) return RequestState.SignedOut(AuthErrorReason.SESSION_TOKEN_MISSING);

        VerifyTokenOptions verifyTokenOptions;

        if (options.JwtKey != null)
            verifyTokenOptions = new VerifyTokenOptions(
                jwtKey: options.JwtKey,
                audiences: options.Audiences,
                authorizedParties: options.AuthorizedParties,
                clockSkewInMs: options.ClockSkewInMs
            );
        else if (options.SecretKey != null)
            verifyTokenOptions = new VerifyTokenOptions(
                options.SecretKey,
                audiences: options.Audiences,
                authorizedParties: options.AuthorizedParties,
                clockSkewInMs: options.ClockSkewInMs
            );
        else
            return RequestState.SignedOut(AuthErrorReason.SECRET_KEY_MISSING);

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
    ///     Checks if the ASP.NET Core HTTP request is authenticated.
    ///     First the session token is retrieved from either the __session cookie
    ///     or the HTTP Authorization header.
    ///     Then the session token is verified: networklessly if the options.jwtKey
    ///     is provided, otherwise by fetching the JWKS from Clerk's Backend API.
    /// </summary>
    /// <param name="request">The ASP.NET Core HTTP request</param>
    /// <param name="options">The request authentication options</param>
    /// <returns>The request state</returns>
    /// <remarks>WARNING: AuthenticateRequestAsync is applicable in the context of Backend APIs only.</remarks>
    public static async Task<RequestState> AuthenticateRequestAsync(
        HttpRequest request,
        AuthenticateRequestOptions options)
    {
        var sessionToken = GetSessionToken(request);
        if (sessionToken == null) return RequestState.SignedOut(AuthErrorReason.SESSION_TOKEN_MISSING);

        VerifyTokenOptions verifyTokenOptions;

        if (options.JwtKey != null)
            verifyTokenOptions = new VerifyTokenOptions(
                jwtKey: options.JwtKey,
                audiences: options.Audiences,
                authorizedParties: options.AuthorizedParties,
                clockSkewInMs: options.ClockSkewInMs
            );
        else if (options.SecretKey != null)
            verifyTokenOptions = new VerifyTokenOptions(
                options.SecretKey,
                audiences: options.Audiences,
                authorizedParties: options.AuthorizedParties,
                clockSkewInMs: options.ClockSkewInMs
            );
        else
            return RequestState.SignedOut(AuthErrorReason.SECRET_KEY_MISSING);

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
    private static string? GetSessionToken(HttpRequestMessage request)
    {
        if (request.Headers.TryGetValues("Authorization", out var authorizationHeaders))
        {
            var bearerToken = authorizationHeaders.FirstOrDefault();
            if (!string.IsNullOrEmpty(bearerToken)) return bearerToken.Replace("Bearer ", "");
        }

        if (request.Headers.TryGetValues("Cookie", out var cookieHeaders))
        {
            var cookieHeaderValue = cookieHeaders.FirstOrDefault();
            if (!string.IsNullOrEmpty(cookieHeaderValue))
            {
                var cookies = cookieHeaderValue.Split(';')
                    .Select(cookie => cookie.Trim())
                    .Select(cookie => new Cookie(cookie.Split('=')[0], cookie.Split('=')[1]));

                foreach (var cookie in cookies)
                    if (cookie.Name == SESSION_COOKIE_NAME)
                        return cookie.Value;
            }
        }

        return null;
    }

    /// <summary>
    ///     Retrieve token from __session cookie or Authorization header.
    /// </summary>
    /// <param name="request">The ASP.NET Core HTTP request</param>
    /// <returns>The session token, if present</returns>
    private static string? GetSessionToken(HttpRequest request)
    {
        // Check for Authorization header
        if (request.Headers.TryGetValue("Authorization", out var authValues))
        {
            var authHeader = authValues.ToString();
            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                return authHeader.Substring("Bearer ".Length).Trim();
            }
        }

        // Check for __session cookie
        if (request.Cookies.TryGetValue(SESSION_COOKIE_NAME, out var sessionCookie))
        {
            return sessionCookie;
        }

        return null;
    }
}
