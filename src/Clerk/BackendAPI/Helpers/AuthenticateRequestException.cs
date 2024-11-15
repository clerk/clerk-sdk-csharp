#nullable enable
namespace Clerk.BackendAPI.Helpers.Jwks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;


    public static class AuthErrorReason
    {
        public static readonly ErrorReason
            SESSION_TOKEN_MISSING = new ErrorReason(
                "session-token-missing",
                "Could not retrieve session token. Please make sure that the __session cookie or the HTTP authorization header contain a Clerk-generated session JWT"
            ),
            SECRET_KEY_MISSING = new ErrorReason(
                "secret-key-missing",
                "Missing Clerk Secret Key. Go to https://dashboard.clerk.com and get your key for your instance."
            );
    }

    public class AuthenticateRequestException : Exception
    {
        public readonly ErrorReason Reason;

        public AuthenticateRequestException(ErrorReason reason) : base(reason.Message)
        {
            this.Reason = reason;
        }

        public AuthenticateRequestException(ErrorReason reason, Exception cause) : base(reason.Message, cause)
        {
            this.Reason = reason;
        }

        public override string ToString()
        {
            return this.Reason.Message;
        }
    }

}
