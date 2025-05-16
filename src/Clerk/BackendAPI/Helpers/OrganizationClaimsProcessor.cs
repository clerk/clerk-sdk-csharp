using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clerk.BackendAPI.Helpers.Jwks;

public static class OrganizationClaimsProcessor
{
    public static ClaimsPrincipal ProcessOrganizationClaims(ClaimsPrincipal claims)
    {
        var claimsIdentity = claims.Identity as ClaimsIdentity;
        if (claimsIdentity == null) return claims;

        var version = claims.FindFirst("v")?.Value;
        if (version != "2") return claims;

        var orgClaim = claims.FindFirst("o");
        if (orgClaim == null) return claims;

        var orgClaims = JsonConvert.DeserializeObject<Dictionary<string, object>>(orgClaim.Value);
        if (orgClaims == null) return claims;

        if (orgClaims.TryGetValue("id", out var orgId))
            claimsIdentity.AddClaim(new Claim("org_id", orgId.ToString() ?? string.Empty));
        if (orgClaims.TryGetValue("slg", out var orgSlug))
            claimsIdentity.AddClaim(new Claim("org_slug", orgSlug.ToString() ?? string.Empty));

        if (orgClaims.TryGetValue("rol", out var orgRole))
        {
            claimsIdentity.AddClaim(new Claim("org_role", orgRole.ToString() ?? string.Empty));
        }

        var features = claims.FindFirst("fea")?.Value?.Split(',');
        var permissions = orgClaims.TryGetValue("per", out var per) ? per.ToString()?.Split(',') : null;
        var mappings = orgClaims.TryGetValue("fpm", out var fpm) ? fpm.ToString()?.Split(',') : null;

        if (features != null && permissions != null && mappings != null)
        {
            var orgPermissions = ComputeOrgPermissions(features, permissions, mappings);
            if (orgPermissions.Any())
            {
                claimsIdentity.AddClaim(new Claim("org_permissions", string.Join(",", orgPermissions)));
            }
        }

        return claims;
    }

    private static IEnumerable<string> ComputeOrgPermissions(string[] features, string[] permissions, string[] mappings)
    {
        var orgPermissions = new List<string>();

        for (int idx = 0; idx < mappings.Length; idx++)
        {
            var mapping = mappings[idx];
            var featureParts = features[idx].Split(':');
            if (featureParts.Length != 2) continue;

            var scope = featureParts[0];
            var feature = featureParts[1];
            if (!scope.Contains("o")) continue;

            var binary = Convert.ToString(int.Parse(mapping), 2).TrimStart('0');
            var reversedBinary = new string(binary.Reverse().ToArray());

            for (int i = 0; i < reversedBinary.Length; i++)
            {
                if (reversedBinary[i] == '1' && i < permissions.Length)
                {
                    orgPermissions.Add($"org:{feature}:{permissions[i]}");
                }
            }
        }

        return orgPermissions;
    }
} 