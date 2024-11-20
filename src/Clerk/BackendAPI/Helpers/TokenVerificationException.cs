using System;

namespace Clerk.BackendAPI.Helpers.Jwks;

public class TokenVerificationException : Exception
{
    public readonly ErrorReason Reason;

    public TokenVerificationException(ErrorReason reason) : base(reason.Message)
    {
        Reason = reason;
    }

    public TokenVerificationException(ErrorReason reason, Exception cause) : base(reason.Message, cause)
    {
        Reason = reason;
    }

    public override string ToString()
    {
        return Reason.Message;
    }
}

public static class TokenVerificationErrorReason
{
    public static readonly ErrorReason
        JWK_FAILED_TO_LOAD = new(
            "jwk-failed-to-load",
            "Failed to load JWKS from Clerk Backend API. Contact support@clerk.com."
        ),
        JWK_REMOTE_INVALID = new(
            "jwk-remote-invalid",
            "The JWKS endpoint did not contain any signing keys. Contact support@clerk.com."
        ),
        JWK_LOCAL_INVALID = new(
            "jwk-local-invalid",
            "The provided PEM Public Key is not in the proper format."
        ),
        JWK_FAILED_TO_RESOLVE = new(
            "jwk-failed-to-resolve",
            "Failed to resolve JWK. Public Key is not in the proper format."
        ),
        JWK_KID_MISMATCH = new(
            "jwk-kid-mismatch",
            "Unable to find a signing key in JWKS that matches the kid of the provided session token."
        ),
        TOKEN_EXPIRED = new(
            "token-expired",
            "Token has expired and is no longer valid."
        ),
        TOKEN_INVALID = new(
            "token-invalid",
            "Token is invalid and could not be verified."
        ),
        TOKEN_INVALID_AUTHORIZED_PARTIES = new(
            "token-invalid-authorized-parties",
            "Authorized party claim (azp) does not match any of the authorized parties."
        ),
        TOKEN_INVALID_AUDIENCE = new(
            "token-invalid-audience",
            "Token audience claim (aud) does not match one of the expected audience values."
        ),
        TOKEN_IAT_IN_THE_FUTURE = new(
            "token-iat-in-the-future",
            "Token Issued At claim (iat) represents a time in the future."
        ),
        TOKEN_NOT_ACTIVE_YET = new(
            "token-not-active-yet",
            "Token is not yet valid. Not Before claim (nbf) is in the future."
        ),
        TOKEN_INVALID_SIGNATURE = new(
            "token-invalid-signature",
            "Token signature is invalid and could not be verified."
        ),
        SECRET_KEY_MISSING = new(
            "secret-key-missing",
            "Missing Clerk Secret Key. Go to https://dashboard.clerk.com and get your key for your instance."
        );
}