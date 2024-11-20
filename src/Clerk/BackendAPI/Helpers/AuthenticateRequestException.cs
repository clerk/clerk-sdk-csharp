using System;

namespace Clerk.BackendAPI.Helpers.Jwks;

public static class AuthErrorReason
{
    public static readonly ErrorReason
        SESSION_TOKEN_MISSING = new(
            "session-token-missing",
            "Could not retrieve session token. Please make sure that the __session cookie or the HTTP authorization header contain a Clerk-generated session JWT"
        ),
        SECRET_KEY_MISSING = new(
            "secret-key-missing",
            "Missing Clerk Secret Key. Go to https://dashboard.clerk.com and get your key for your instance."
        );
}

public class AuthenticateRequestException : Exception
{
    public readonly ErrorReason Reason;

    public AuthenticateRequestException(ErrorReason reason) : base(reason.Message)
    {
        Reason = reason;
    }

    public AuthenticateRequestException(ErrorReason reason, Exception cause) : base(reason.Message, cause)
    {
        Reason = reason;
    }

    public override string ToString()
    {
        return Reason.Message;
    }
}