using System.Collections.Generic;
using System.Linq;

namespace Clerk.BackendAPI.Helpers.Jwks;

public sealed class AuthenticateRequestOptions
{
    private static readonly long DEFAULT_CLOCK_SKEW_MS = 5000L;
    public readonly IEnumerable<string>? Audiences;
    public readonly IEnumerable<string> AuthorizedParties;
    public readonly long ClockSkewInMs;
    public readonly string? JwtKey;
    public readonly string? SecretKey;
    public readonly string? MachineSecretKey;
    public readonly IEnumerable<string> AcceptsToken;

    /// <summary>
    ///     Options to configure AuthenticateRequestAsync.
    /// </summary>
    /// <param name="secretKey">The Clerk secret key from the API Keys page in the Clerk Dashboard. (Optional)</param>
    /// <param name="machineSecretKey">The Machine secret key for machine-specific authentication. (Optional)</param>
    /// <param name="jwtKey">PEM Public String used to verify the session token in a networkless manner. (Optional)</param>
    /// <param name="audiences">A list of audiences to verify against.</param>
    /// <param name="authorizedParties">An allowlist of origins to verify against.</param>
    /// <param name="clockSkewInMs">
    ///     Allowed time difference (in milliseconds) between the Clerk server (which generates the
    ///     token) and the user's application server when validating a token. Defaults to 5000 ms.
    /// </param>
    /// <param name="acceptsToken">A list of token types to accept. Defaults to ["any"].</param>
    public AuthenticateRequestOptions(
        string? secretKey = null,
        string? machineSecretKey = null,
        string? jwtKey = null,
        IEnumerable<string>? audiences = null,
        IEnumerable<string>? authorizedParties = null,
        long? clockSkewInMs = null,
        IEnumerable<string>? acceptsToken = null)
    {
        if (string.IsNullOrEmpty(secretKey) && string.IsNullOrEmpty(jwtKey) && string.IsNullOrEmpty(machineSecretKey))
            throw new AuthenticateRequestException(AuthErrorReason.SECRET_KEY_MISSING);

        SecretKey = secretKey;
        MachineSecretKey = machineSecretKey;
        JwtKey = jwtKey;
        Audiences = audiences;
        AuthorizedParties = authorizedParties ?? new List<string>();
        ClockSkewInMs = clockSkewInMs ?? DEFAULT_CLOCK_SKEW_MS;
        AcceptsToken = acceptsToken ?? new[] { "any" };
    }
}
