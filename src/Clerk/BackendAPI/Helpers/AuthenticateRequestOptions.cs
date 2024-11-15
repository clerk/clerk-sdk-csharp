#nullable enable
namespace Clerk.BackendAPI.Helpers.Jwks
{
    using Clerk.BackendAPI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public sealed class AuthenticateRequestOptions
    {
        private static readonly long DEFAULT_CLOCK_SKEW_MS = 5000L;

        public readonly string? SecretKey;
        public readonly string? JwtKey;
        public readonly IEnumerable<string>? Audiences;
        public readonly IEnumerable<string> AuthorizedParties;
        public readonly long ClockSkewInMs;

        /// <summary>
        /// Options to configure AuthenticateRequest.
        ///
        /// </summary>
        /// <param name="secretKey">The Clerk secret key from the API Keys page in the Clerk Dashboard. (Optional)</param>
        /// <param name="jwtKey">PEM Public String used to verify the session token in a networkless manner. (Optional)</param>
        /// <param name="audiences">A list of audiences to verify against.</param>
        /// <param name="authorizedParties">An allowlist of origins to verify against.</param>
        /// <param name="clockSkewInMs">Allowed time difference (in milliseconds) between the Clerk server (which generates the token) and the clock of the user's application server when validating a token. Defaults to 5000 ms.</param>
        public AuthenticateRequestOptions(
            string? secretKey = null,
            string? jwtKey = null,
            ClerkBackendApi? sdk = null,
            IEnumerable<string>? audiences = null,
            IEnumerable<string>? authorizedParties = null,
            long? clockSkewInMs = null)
        {
            if (sdk != null)
            {

            }
            if (string.IsNullOrEmpty(secretKey) && string.IsNullOrEmpty(jwtKey))
            {
                if (sdk == null)
                {
                    throw new AuthenticateRequestException(AuthErrorReason.SECRET_KEY_MISSING);
                }
            }

            SecretKey = secretKey;
            JwtKey = jwtKey;
            Audiences = audiences;
            AuthorizedParties = authorizedParties ?? new List<string>();
            ClockSkewInMs = clockSkewInMs ?? DEFAULT_CLOCK_SKEW_MS;
        }
    }

}
