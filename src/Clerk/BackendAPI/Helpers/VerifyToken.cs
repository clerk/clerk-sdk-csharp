using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Utils;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

using WellKnownJWKS = Clerk.BackendAPI.Models.Components.Jwks;

namespace Clerk.BackendAPI.Helpers.Jwks;

public static class VerifyToken
{
    public static async Task<ClaimsPrincipal> VerifyTokenAsync(string token, VerifyTokenOptions options)
    {
        var tokenType = TokenTypeHelper.GetTokenType(token);

        if (tokenType == TokenType.SessionToken)
        {
            return await VerifySessionTokenAsync(token, options);
        }
        else if (TokenTypeHelper.IsMachineToken(token))
        {
            return await VerifyMachineTokenAsync(token, options, tokenType);
        }
        else
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.INVALID_TOKEN_TYPE);
        }
    }

    private static async Task<ClaimsPrincipal> VerifySessionTokenAsync(string token, VerifyTokenOptions options)
    {
        RsaSecurityKey rsaKey;
        if (options.JwtKey != null)
            rsaKey = GetLocalJwtKey(options.JwtKey);
        else
            rsaKey = await GetRemoteJwtKeyAsync(token, options);

        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = options.Audiences != null,
            ValidAudiences = options.Audiences,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = rsaKey,
            ClockSkew = TimeSpan.FromMilliseconds(options.ClockSkewInMs)
        };

        ClaimsPrincipal claims;
        try
        {
            claims = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
        }
        catch (SecurityTokenExpiredException ex)
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_EXPIRED, ex);
        }
        catch (SecurityTokenNotYetValidException ex)
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_NOT_ACTIVE_YET, ex);
        }
        catch (SecurityTokenInvalidSignatureException ex)
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_INVALID_SIGNATURE, ex);
        }
        catch (SecurityTokenInvalidAudienceException ex)
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_INVALID_AUDIENCE, ex);
        }
        catch (Exception ex)
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_INVALID, ex);
        }

        if (options.AuthorizedParties != null)
        {
            var azpClaim = claims.FindFirst("azp");
            if (azpClaim != null && !options.AuthorizedParties.Contains(azpClaim.Value))
                throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_INVALID_AUTHORIZED_PARTIES);
        }

        var iatClaim = claims.FindFirst("iat");
        if (iatClaim != null && long.Parse(iatClaim.Value) >
            DateTimeOffset.UtcNow.ToUnixTimeSeconds() + options.ClockSkewInMs / 1000)
            throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_IAT_IN_THE_FUTURE);

        claims = OrganizationClaimsProcessor.ProcessOrganizationClaims(claims);
        return claims;
    }

    /// <summary>
    ///     Converts a RSA PEM formatted public key to a RsaSecurityKey object
    ///     that can be used for networkless verification.
    /// </summary>
    /// <param name="jwtKey">The PEM formatted public key.</param>
    /// <returns>The RSA public key</returns>
    /// <exception cref="TokenVerificationException">if the public key could not be resolved.</exception>
    private static RsaSecurityKey GetLocalJwtKey(string jwtKey)
    {
        try
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(jwtKey.ToCharArray());
            return new RsaSecurityKey(rsa);
        }
        catch (Exception ex)
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.JWK_LOCAL_INVALID, ex);
        }
    }

    /// <summary>
    ///     Retrieves the RSA public key used to sign the token from Clerk's Backend API.
    /// </summary>
    /// <param name="token">The token to parse.</param>
    /// <param name="options">The options used for token verification.</param>
    /// <returns>The RSA public key.</returns>
    /// <exception cref="TokenVerificationException">if the public key could not be resolved.</exception>
    private static async Task<RsaSecurityKey> GetRemoteJwtKeyAsync(string token, VerifyTokenOptions options)
    {
        var kid = ParseKid(token);

        var jwks = await FetchJwksAsync(options);
        if (jwks.Keys == null) throw new TokenVerificationException(TokenVerificationErrorReason.JWK_REMOTE_INVALID);

        foreach (var key in jwks.Keys)
            if (key.Kid == kid)
            {
                if ((key.N == null) | (key.E == null))
                    throw new TokenVerificationException(TokenVerificationErrorReason.JWK_REMOTE_INVALID);
                try
                {
                    var rsaParameters = new RSAParameters
                    {
                        Modulus = Base64UrlDecode(key.N!),
                        Exponent = Base64UrlDecode(key.E!)
                    };
                    var rsa = RSA.Create();
                    rsa.ImportParameters(rsaParameters);

                    return new RsaSecurityKey(rsa);
                }
                catch (Exception ex)
                {
                    throw new TokenVerificationException(TokenVerificationErrorReason.JWK_FAILED_TO_RESOLVE, ex);
                }
            }

        throw new TokenVerificationException(TokenVerificationErrorReason.JWK_KID_MISMATCH);
    }


    /// <summary>
    ///     Decodes a base64url encoded string.
    /// </summary>
    /// <param name="input">The base64url encoded string.</param>
    /// <returns>The decoded byte array.</returns>
    private static byte[] Base64UrlDecode(string input)
    {
        var base64 = input.Replace('-', '+').Replace('_', '/');
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        return Convert.FromBase64String(base64);
    }

    /// <summary>
    ///     Retrieves the key identifier (kid) from the token header.
    /// </summary>
    /// <param name="token">The token to parse.</param>
    /// <returns>The key identifier (kid).</returns>
    /// <exception cref="TokenVerificationException">if the kid cannot be parsed.</exception>
    private static string ParseKid(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        if (handler.CanReadToken(token))
            try
            {
                var jwtToken = handler.ReadJwtToken(token);

                if (jwtToken.Header.TryGetValue("kid", out var kid))
                    if (kid != null)
                        return (string)kid;
            }
            catch (Exception ex)
            {
                throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_INVALID, ex);
            }

        throw new TokenVerificationException(TokenVerificationErrorReason.JWK_KID_MISMATCH);
    }

    /// <summary>
    ///     Fetches the JSON Web Key Set (JWKS) from Clerk's Backend API.
    /// </summary>
    /// <param name="options">The options used for token verification.</param>
    /// <returns>The JWKS keys array as a JSON node.</returns>
    /// <exception cref="TokenVerificationException">if the JWKS cannot be fetched.</exception>
    private static async Task<WellKnownJWKS> FetchJwksAsync(VerifyTokenOptions options)
    {
        if (options.SecretKey == null)
            throw new TokenVerificationException(TokenVerificationErrorReason.SECRET_KEY_MISSING);

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.SecretKey);
            var jwksUrl = $"{options.ApiUrl}/{options.ApiVersion}/jwks";


            var httpResponse = await client.GetAsync(jwksUrl);
            if (!httpResponse.IsSuccessStatusCode)
                throw new TokenVerificationException(TokenVerificationErrorReason.JWK_FAILED_TO_LOAD);

            var responseBody = await httpResponse.Content.ReadAsStringAsync();

            WellKnownJWKS? wellKnownJWKS;
            try
            {
                wellKnownJWKS = ResponseBodyDeserializer.Deserialize<WellKnownJWKS>(responseBody);
            }
            catch (JsonReaderException ex)
            {
                throw new TokenVerificationException(TokenVerificationErrorReason.JWK_FAILED_TO_LOAD, ex);
            }

            if (wellKnownJWKS == null)
                throw new TokenVerificationException(TokenVerificationErrorReason.JWK_REMOTE_INVALID);

            return wellKnownJWKS!;
        }
    }

    /// <summary>
    /// Verifies machine tokens (M2M, OAuth, API keys) by making API calls to Clerk's backend
    /// </summary>
    /// <param name="token">The machine token to verify</param>
    /// <param name="options">Verification options</param>
    /// <param name="tokenType">The type of machine token</param>
    /// <returns>ClaimsPrincipal containing token information</returns>
    private static async Task<ClaimsPrincipal> VerifyMachineTokenAsync(string token, VerifyTokenOptions options, TokenType tokenType)
    {
        if (options.SecretKey == null && options.MachineSecretKey == null)
            throw new TokenVerificationException(TokenVerificationErrorReason.SECRET_KEY_MISSING);

        var endpoint = TokenTypeHelper.GetVerificationEndpoint(tokenType);
        var verificationUrl = $"{options.ApiUrl}/{options.ApiVersion}{endpoint}";

        using var client = new HttpClient();

        var authToken = options.SecretKey ?? options.MachineSecretKey;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var payload = new { secret = token };
        var jsonContent = JsonConvert.SerializeObject(payload);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync(verificationUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_INVALID);
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var tokenData = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseBody);

            if (tokenData == null)
            {
                throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_INVALID);
            }

            // Create claims from the token verification response
            var claims = new List<Claim>();

            foreach (var kvp in tokenData)
            {
                if (kvp.Value != null)
                {
                    claims.Add(new Claim(kvp.Key, kvp.Value.ToString()!));
                }
            }

            var identity = new ClaimsIdentity(claims, "ClerkMachineToken");
            return new ClaimsPrincipal(identity);
        }
        catch (HttpRequestException ex)
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.SERVER_ERROR, ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.SERVER_ERROR, ex);
        }
        catch (JsonException ex)
        {
            throw new TokenVerificationException(TokenVerificationErrorReason.TOKEN_INVALID, ex);
        }
    }
}