namespace Clerk.BackendAPI.Helpers.Jwks;

/// <summary>
///     Represents the reason for a TokenVerificationException or AuthenticateRequestException.
/// </summary>
public class ErrorReason
{
    public readonly string Id;
    public readonly string Message;

    public ErrorReason(string id, string message)
    {
        Id = id;
        Message = message;
    }
}