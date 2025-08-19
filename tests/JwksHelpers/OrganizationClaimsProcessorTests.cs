using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clerk.BackendAPI.Helpers.Jwks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Xunit;

namespace JwksHelpers.Tests;

public class OrganizationClaimsProcessorTests
{
    [Fact]
    public void ProcessOrganizationClaims_WithValidClaims_AddsOrganizationClaims()
    {
        var claims = new List<Claim>
        {
            new Claim("v", "2"),
            new Claim("o", JsonConvert.SerializeObject(new Dictionary<string, object>
            {
                ["id"] = "org_123",
                ["slg"] = "test-org",
                ["rol"] = "admin",
                ["per"] = "read,write",
                ["fpm"] = "3,1"
            })),
            new Claim("fea", "o:users,o:settings")
        };

        var identity = new ClaimsIdentity(claims);
        var principal = new ClaimsPrincipal(identity);

        var result = OrganizationClaimsProcessor.ProcessOrganizationClaims(principal);

        Assert.Equal("org_123", result.FindFirst("org_id")?.Value);
        Assert.Equal("test-org", result.FindFirst("org_slug")?.Value);
        Assert.Equal("admin", result.FindFirst("org_role")?.Value);
        
        var orgPermissions = result.FindFirst("org_permissions")?.Value;
        Assert.NotNull(orgPermissions);
        Assert.Contains("org:users:read", orgPermissions);
        Assert.Contains("org:users:write", orgPermissions);
        Assert.Contains("org:settings:read", orgPermissions);
    }

    [Fact]
    public void ProcessOrganizationClaims_WithInvalidVersion_ReturnsOriginalClaims()
    {
        var claims = new List<Claim>
        {
            new Claim("v", "1"),
            new Claim("o", "{}"),
            new Claim("fea", "o:users")
        };

        var identity = new ClaimsIdentity(claims);
        var principal = new ClaimsPrincipal(identity);

        var result = OrganizationClaimsProcessor.ProcessOrganizationClaims(principal);

        Assert.Null(result.FindFirst("org_id"));
        Assert.Null(result.FindFirst("org_slug"));
        Assert.Null(result.FindFirst("org_role"));
        Assert.Null(result.FindFirst("org_permissions"));
    }

    [Fact]
    public void ProcessOrganizationClaims_WithMissingOrgClaim_ReturnsOriginalClaims()
    {
        var claims = new List<Claim>
        {
            new Claim("v", "2"),
            new Claim("fea", "o:users")
        };

        var identity = new ClaimsIdentity(claims);
        var principal = new ClaimsPrincipal(identity);

        var result = OrganizationClaimsProcessor.ProcessOrganizationClaims(principal);

        Assert.Null(result.FindFirst("org_id"));
        Assert.Null(result.FindFirst("org_slug"));
        Assert.Null(result.FindFirst("org_role"));
        Assert.Null(result.FindFirst("org_permissions"));
    }
} 