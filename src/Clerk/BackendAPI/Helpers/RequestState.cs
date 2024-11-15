#nullable enable
namespace Clerk.BackendAPI.Helpers.Jwks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;

    /// <summary>
    /// AuthStatus - The request authentication status.
    /// </summary>
    public class AuthStatus
    {
        public static readonly AuthStatus SignedIn = new AuthStatus("signed-in");
        public static readonly AuthStatus SignedOut = new AuthStatus("signed-out");

        private readonly string value;

        private AuthStatus(string value)
        {
            this.value = value;
        }

        public string Value()
        {
            return value;
        }
    }

    /// <summary>
    /// RequestState - Authentication State of the request.
    /// </summary>
    public class RequestState
    {
        public readonly AuthStatus Status;
        public readonly ErrorReason? ErrorReason;
        public readonly string? Token;
        public readonly ClaimsPrincipal? Claims;


        public RequestState(AuthStatus status,
                            ErrorReason? errorReason,
                            string? token,
                            ClaimsPrincipal? claims)
        {
            Status = status;
            ErrorReason = errorReason;
            Token = token;
            Claims = claims;
        }

        public static RequestState SignedIn(string token, ClaimsPrincipal claims)
        {
            return new RequestState(AuthStatus.SignedIn, null, token, claims);
        }

        public static RequestState SignedOut(ErrorReason errorReason)
        {
            return new RequestState(AuthStatus.SignedOut, errorReason, null, null);
        }

        public bool IsSignedIn()
        {
            return Status == AuthStatus.SignedIn;
        }

        public bool IsSignedOut()
        {
            return Status == AuthStatus.SignedOut;
        }
    }

}
