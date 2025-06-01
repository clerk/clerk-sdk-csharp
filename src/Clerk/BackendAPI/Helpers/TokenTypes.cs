using System;

namespace Clerk.BackendAPI.Helpers.Jwks;

/// <summary>
/// Represents different types of Clerk tokens
/// </summary>
public enum TokenType
{
    SessionToken,
    MachineToken,
    OAuthToken,
    ApiKey
}

/// <summary>
/// Token prefixes used to identify token types
/// </summary>
public static class TokenPrefix
{
    public const string MachineToken = "mt_";
    public const string OAuthToken = "oat_";
    public const string ApiKey = "ak_";
}

/// <summary>
/// Helper methods for token type detection and classification
/// </summary>
public static class TokenTypeHelper
{
    private static readonly string[] MachineTokenPrefixes = { TokenPrefix.MachineToken, TokenPrefix.OAuthToken, TokenPrefix.ApiKey };

    /// <summary>
    /// Determines if a token is a machine token (includes M2M, OAuth, and API key tokens)
    /// </summary>
    /// <param name="token">The token to check</param>
    /// <returns>True if the token is a machine token</returns>
    public static bool IsMachineToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return false;

        foreach (var prefix in MachineTokenPrefixes)
        {
            if (token.StartsWith(prefix))
                return true;
        }

        return false;
    }

    /// <summary>
    /// Gets the token type based on its prefix
    /// </summary>
    /// <param name="token">The token to analyze</param>
    /// <returns>The detected token type</returns>
    public static TokenType GetTokenType(string token)
    {
        if (string.IsNullOrEmpty(token))
            return TokenType.SessionToken;

        if (token.StartsWith(TokenPrefix.MachineToken))
            return TokenType.MachineToken;
        
        if (token.StartsWith(TokenPrefix.ApiKey))
            return TokenType.ApiKey;
        
        if (token.StartsWith(TokenPrefix.OAuthToken))
            return TokenType.OAuthToken;

        return TokenType.SessionToken;
    }

    /// <summary>
    /// Gets the verification endpoint for a given token type
    /// </summary>
    /// <param name="tokenType">The token type</param>
    /// <returns>The API endpoint for verification</returns>
    public static string GetVerificationEndpoint(TokenType tokenType)
    {
        return tokenType switch
        {
            TokenType.MachineToken => "/m2m_tokens/verify",
            TokenType.OAuthToken => "/oauth_applications/access_tokens/verify",
            TokenType.ApiKey => "/api_keys/verify",
            _ => throw new ArgumentException($"No verification endpoint for token type: {tokenType}")
        };
    }
} 