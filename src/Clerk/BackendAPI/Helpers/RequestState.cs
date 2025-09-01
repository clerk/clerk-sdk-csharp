using System;
using System.Linq;
using System.Security.Claims;

namespace Clerk.BackendAPI.Helpers.Jwks;

/// <summary>
///     AuthStatus - The request authentication status.
/// </summary>
public class AuthStatus
{
    public static readonly AuthStatus SignedIn = new("signed-in");
    public static readonly AuthStatus SignedOut = new("signed-out");

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
///     RequestState - Authentication State of the request.
/// </summary>
public class RequestState
{
    public readonly ClaimsPrincipal? Claims;
    public readonly ErrorReason? ErrorReason;
    public readonly AuthStatus Status;
    public readonly string? Token;


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

    public bool IsAuthenticated => Status == AuthStatus.SignedIn;

    [Obsolete("Use IsAuthenticated instead.")]
    public bool IsSignedIn()
    {
        return Status == AuthStatus.SignedIn;
    }

    public bool IsSignedOut()
    {
        return Status == AuthStatus.SignedOut;
    }

    public AuthObject ToAuth()
    {
        if (Status != AuthStatus.SignedIn || Claims == null)
            throw new InvalidOperationException("Cannot convert to auth object when not signed in.");

        var tokenType = TokenTypeHelper.GetTokenType(Token);
        switch (tokenType)
        {
            case TokenType.SessionToken:
                var versionClaim = Claims.FindFirst("v")?.Value;
                if (versionClaim == "2")
                {
                    return new SessionAuthObjectV2
                    {
                        Azp = Claims.FindFirst("azp")?.Value,
                        Email = Claims.FindFirst("email")?.Value,
                        Exp = int.Parse(Claims.FindFirst("exp")?.Value ?? "0"),
                        Fva = Claims.FindAll("fva").Select(c => int.Parse(c.Value)).ToList(),
                        Iat = int.Parse(Claims.FindFirst("iat")?.Value ?? "0"),
                        Iss = Claims.FindFirst("iss")?.Value,
                        Jti = Claims.FindFirst("jti")?.Value,
                        Nbf = int.Parse(Claims.FindFirst("nbf")?.Value ?? "0"),
                        Role = Claims.FindFirst("role")?.Value,
                        Sid = Claims.FindFirst("sid")?.Value,
                        Sub = Claims.FindFirst("sub")?.Value,
                        V = int.Parse(versionClaim)
                    };
                }
                return new SessionAuthObjectV1
                {
                    SessionId = Claims.FindFirst("sid")?.Value,
                    UserId = Claims.FindFirst("sub")?.Value,
                    OrgId = Claims.FindFirst("org_id")?.Value,
                    OrgRole = Claims.FindFirst("org_role")?.Value,
                    OrgPermissions = Claims.FindAll("org_permissions").Select(c => c.Value).ToList(),
                    FactorVerificationAge = Claims.FindAll("fva").Select(c => int.Parse(c.Value)).ToList(),
                    Claims = Claims.Claims.GroupBy(c => c.Type).ToDictionary(g => g.Key, g => (object)g.Select(c => c.Value).ToList())
                };
            case TokenType.OAuthToken:
                return new OAuthMachineAuthObject
                {
                    Id = Claims.FindFirst("id")?.Value,
                    UserId = Claims.FindFirst("subject")?.Value,
                    ClientId = Claims.FindFirst("client_id")?.Value,
                    Name = Claims.FindFirst("name")?.Value,
                    Scopes = Claims.FindAll("scopes").Select(c => c.Value).ToList()
                };
            case TokenType.ApiKey:
                return new APIKeyMachineAuthObject
                {
                    Id = Claims.FindFirst("id")?.Value,
                    UserId = Claims.FindFirst("subject")?.Value,
                    OrgId = Claims.FindFirst("org_id")?.Value,
                    Name = Claims.FindFirst("name")?.Value,
                    Scopes = Claims.FindAll("scopes").Select(c => c.Value).ToList(),
                    Claims = Claims.Claims.GroupBy(c => c.Type).ToDictionary(g => g.Key, g => (object)g.Select(c => c.Value).ToList())
                };
            case TokenType.MachineToken:
            case TokenType.MachineTokenV2:
                return new M2MMachineAuthObject
                {
                    Id = Claims.FindFirst("id")?.Value,
                    MachineId = Claims.FindFirst("subject")?.Value,
                    ClientId = Claims.FindFirst("client_id")?.Value,
                    Name = Claims.FindFirst("name")?.Value,
                    Scopes = Claims.FindAll("scopes").Select(c => c.Value).ToList(),
                    Claims = Claims.Claims.GroupBy(c => c.Type).ToDictionary(g => g.Key, g => (object)g.Select(c => c.Value).ToList())
                };
            default:
                throw new InvalidOperationException($"Unsupported token type: {tokenType}");
        }
    }
}