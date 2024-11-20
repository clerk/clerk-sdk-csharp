using System.Collections.Generic;

namespace Clerk.BackendAPI.Helpers.Jwks;

public sealed class VerifyTokenOptions
{
    private static readonly long DEFAULT_CLOCK_SKEW_MS = 5000L;
    private static readonly string DEFAULT_API_URL = "https://api.clerk.com";
    private static readonly string DEFAULT_API_VERSION = "v1";
    public readonly string ApiUrl;
    public readonly string ApiVersion;
    public readonly IEnumerable<string>? Audiences;
    public readonly IEnumerable<string>? AuthorizedParties;
    public readonly long ClockSkewInMs;
    public readonly string? JwtKey;

    public readonly string? SecretKey;

    /// <summary>
    ///     Options to configure VerifyTokenAsync.
    /// </summary>
    /// <param name="secretKey">The Clerk secret key from the API Keys page in the Clerk Dashboard. (Optional)</param>
    /// <param name="jwtKey">PEM Public String used to verify the session token in a networkless manner. (Optional)</param>
    /// <param name="audiences">A list of audiences to verify against.</param>
    /// <param name="authorizedParties">An allowlist of origins to verify against.</param>
    /// <param name="clockSkewInMs">
    ///     Allowed time difference (in milliseconds) between the Clerk server (which generates the
    ///     token) and the clock of the user's application server when validating a token. Defaults to 5000 ms.
    /// </param>
    /// <param name="apiUrl">The Clerk Backend API endpoint. Defaults to 'https://api.clerk.com'</param>
    /// <param name="apiVersion">The version passed to the Clerk API. Defaults to 'v1'</param>
    public VerifyTokenOptions(
        string? secretKey = null,
        string? jwtKey = null,
        IEnumerable<string>? audiences = null,
        IEnumerable<string>? authorizedParties = null,
        long? clockSkewInMs = null,
        string? apiUrl = null,
        string? apiVersion = null)
    {
        if (string.IsNullOrEmpty(secretKey) && string.IsNullOrEmpty(jwtKey))
            throw new TokenVerificationException(TokenVerificationErrorReason.SECRET_KEY_MISSING);

        SecretKey = secretKey;
        JwtKey = jwtKey;
        Audiences = audiences;
        AuthorizedParties = authorizedParties;
        ClockSkewInMs = clockSkewInMs ?? DEFAULT_CLOCK_SKEW_MS;
        ApiUrl = apiUrl ?? DEFAULT_API_URL;
        ApiVersion = apiVersion ?? DEFAULT_API_VERSION;
    }
}