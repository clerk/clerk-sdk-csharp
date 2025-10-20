using System.Collections.Generic;

namespace Clerk.BackendAPI.Helpers.Jwks
{
    /// <summary>
    /// Abstract base class for all authentication objects
    /// </summary>
    public abstract class AuthObject
    {
    }

    /// <summary>
    /// Session authentication object for version 2 tokens
    /// </summary>
    public class SessionAuthObjectV2 : AuthObject
    {
        public string? Azp { get; set; }
        public string? Email { get; set; }
        public int Exp { get; set; }
        public List<int>? Fva { get; set; }
        public int Iat { get; set; }
        public string? Iss { get; set; }
        public string? Jti { get; set; }
        public int Nbf { get; set; }
        public string? Role { get; set; }
        public string? Sid { get; set; }
        public string? Sub { get; set; }
        public int V { get; set; }
    }

    /// <summary>
    /// Session authentication object for version 1 tokens
    /// </summary>
    public class SessionAuthObjectV1 : AuthObject
    {
        public string? SessionId { get; set; }
        public string? UserId { get; set; }
        public string? OrgId { get; set; }
        public string? OrgRole { get; set; }
        public List<string>? OrgPermissions { get; set; }
        public List<int>? FactorVerificationAge { get; set; }
        public Dictionary<string, object>? Claims { get; set; }
    }

    /// <summary>
    /// OAuth machine authentication object
    /// </summary>
    public class OAuthMachineAuthObject : AuthObject
    {
        public TokenType TokenType { get; set; } = TokenType.OAuthToken;
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? ClientId { get; set; }
        public string? Name { get; set; }
        public List<string>? Scopes { get; set; }
    }

    /// <summary>
    /// API key machine authentication object
    /// </summary>
    public class APIKeyMachineAuthObject : AuthObject
    {
        public TokenType TokenType { get; set; } = TokenType.ApiKey;
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? OrgId { get; set; }
        public string? Name { get; set; }
        public List<string>? Scopes { get; set; }
        public Dictionary<string, object>? Claims { get; set; }
    }

    /// <summary>
    /// M2M machine authentication object
    /// </summary>
    public class M2MMachineAuthObject : AuthObject
    {
        public TokenType TokenType { get; set; } = TokenType.MachineToken;
        public string? Id { get; set; }
        public string? MachineId { get; set; }
        public string? ClientId { get; set; }
        public string? Name { get; set; }
        public List<string>? Scopes { get; set; }
        public Dictionary<string, object>? Claims { get; set; }
    }
}