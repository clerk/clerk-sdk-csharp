#nullable enable
namespace Clerk.BackendAPI.Helpers.Jwks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class TokenVerificationException : Exception
    {
        public readonly ErrorReason Reason;

        public TokenVerificationException(ErrorReason reason) : base(reason.Message)
        {
            this.Reason = reason;
        }

        public TokenVerificationException(ErrorReason reason, Exception cause) : base(reason.Message, cause)
        {
            this.Reason = reason;
        }

        public override string ToString()
        {
            return this.Reason.Message;
        }
    }

    public static class TokenVerificationErrorReason
    {
        public static readonly ErrorReason
            JWK_FAILED_TO_LOAD = new ErrorReason(
                "jwk-failed-to-load",
                "Failed to load JWKS from Clerk Backend API. Contact support@clerk.com."
            ),
            JWK_REMOTE_INVALID = new ErrorReason(
                "jwk-remote-invalid",
                "The JWKS endpoint did not contain any signing keys. Contact support@clerk.com."
            ),
            JWK_LOCAL_INVALID = new ErrorReason(
                "jwk-local-invalid",
                "The provided PEM Public Key is not in the proper format."
            ),
            JWK_FAILED_TO_RESOLVE = new ErrorReason(
                "jwk-failed-to-resolve",
                "Failed to resolve JWK. Public Key is not in the proper format."
            ),
            JWK_KID_MISMATCH = new ErrorReason(
                "jwk-kid-mismatch",
                "Unable to find a signing key in JWKS that matches the kid of the provided session token."
            ),
            TOKEN_EXPIRED = new ErrorReason(
                "token-expired",
                "Token has expired and is no longer valid."
            ),
            TOKEN_INVALID = new ErrorReason(
                "token-invalid",
                "Token is invalid and could not be verified."
            ),
            TOKEN_INVALID_AUTHORIZED_PARTIES = new ErrorReason(
                "token-invalid-authorized-parties",
                "Authorized party claim (azp) does not match any of the authorized parties."
            ),
            TOKEN_INVALID_AUDIENCE = new ErrorReason(
                "token-invalid-audience",
                "Token audience claim (aud) does not match one of the expected audience values."
            ),
            TOKEN_IAT_IN_THE_FUTURE = new ErrorReason(
                "token-iat-in-the-future",
                "Token Issued At claim (iat) represents a time in the future."
            ),
            TOKEN_NOT_ACTIVE_YET = new ErrorReason(
                "token-not-active-yet",
                "Token is not yet valid. Not Before claim (nbf) is in the future."
            ),
            TOKEN_INVALID_SIGNATURE = new ErrorReason(
                "token-invalid-signature",
                "Token signature is invalid and could not be verified."
            ),
            SECRET_KEY_MISSING = new ErrorReason(
                "secret-key-missing",
                "Missing Clerk Secret Key. Go to https://dashboard.clerk.com and get your key for your instance."
            );
    }
}
