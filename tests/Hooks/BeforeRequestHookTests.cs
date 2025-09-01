using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Clerk.BackendAPI;
using Clerk.BackendAPI.Hooks;
using Xunit;

public class ClerkBeforeRequestHookTests
{
    [Fact]
    public async Task BeforeRequestAsync_AddsClerkApiVersionHeader()
    {
        var hook = new ClerkBeforeRequestHook();
        var request = new HttpRequestMessage();
        var sdkConfig = new SDKConfig();
        var hookCtx = new BeforeRequestContext(new HookContext(sdkConfig, "test", "test-operation", null, null));

        var result = await hook.BeforeRequestAsync(hookCtx, request);

        Assert.True(result.Headers.Contains("Clerk-API-Version"));
        Assert.Equal("2025-04-10", result.Headers.GetValues("Clerk-API-Version").First());
    }

    [Fact]
    public void Constructor_WithValidOrigin_SetsOrigin()
    {
        // Arrange & Act
        var hook = new ClerkBeforeRequestHook("https://example.com");

        // Assert
        Assert.NotNull(hook);
    }

    [Fact]
    public void Constructor_WithNullOrigin_DoesNotThrow()
    {
        // Arrange & Act & Assert
        var hook = new ClerkBeforeRequestHook(null);
        Assert.NotNull(hook);
    }

    [Fact]
    public async Task BeforeRequestAsync_WithCreateSessionToken_AddsOriginHeader()
    {
        // Arrange
        var hook = new ClerkBeforeRequestHook("https://example.com");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.clerk.com/v1/sessions/123/tokens");
        var hookCtx = new BeforeRequestContext(new HookContext(
            new SDKConfig(),
            "https://api.clerk.com/v1",
            "CreateSessionToken",
            null,
            null
        ));

        // Act
        var result = await hook.BeforeRequestAsync(hookCtx, request);

        // Assert
        Assert.True(result.Headers.Contains("Origin"));
        Assert.Equal("https://example.com", result.Headers.GetValues("Origin").First());
        Assert.True(result.Headers.Contains("Clerk-API-Version"));
    }

    [Fact]
    public async Task BeforeRequestAsync_WithCreateSessionTokenFromTemplate_AddsOriginHeader()
    {
        // Arrange
        var hook = new ClerkBeforeRequestHook("https://example.com");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.clerk.com/v1/sessions/123/tokens/template");
        var hookCtx = new BeforeRequestContext(new HookContext(
            new SDKConfig(),
            "https://api.clerk.com/v1",
            "CreateSessionTokenFromTemplate",
            null,
            null
        ));

        // Act
        var result = await hook.BeforeRequestAsync(hookCtx, request);

        // Assert
        Assert.True(result.Headers.Contains("Origin"));
        Assert.Equal("https://example.com", result.Headers.GetValues("Origin").First());
        Assert.True(result.Headers.Contains("Clerk-API-Version"));
    }

    [Fact]
    public async Task BeforeRequestAsync_WithOtherOperation_DoesNotAddOriginHeader()
    {
        // Arrange
        var hook = new ClerkBeforeRequestHook("https://example.com");
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.clerk.com/v1/users");
        var hookCtx = new BeforeRequestContext(new HookContext(
            new SDKConfig(),
            "https://api.clerk.com/v1",
            "GetUserList",
            null,
            null
        ));

        // Act
        var result = await hook.BeforeRequestAsync(hookCtx, request);

        // Assert
        Assert.False(result.Headers.Contains("Origin"));
        Assert.True(result.Headers.Contains("Clerk-API-Version"));
    }

    [Fact]
    public async Task BeforeRequestAsync_WithExistingOriginHeader_DoesNotOverride()
    {
        // Arrange
        var hook = new ClerkBeforeRequestHook("https://example.com");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.clerk.com/v1/sessions/123/tokens");
        request.Headers.Add("Origin", "https://existing.com");
        var hookCtx = new BeforeRequestContext(new HookContext(
            new SDKConfig(),
            "https://api.clerk.com/v1",
            "CreateSessionToken",
            null,
            null
        ));

        // Act
        var result = await hook.BeforeRequestAsync(hookCtx, request);

        // Assert
        Assert.True(result.Headers.Contains("Origin"));
        Assert.Equal("https://existing.com", result.Headers.GetValues("Origin").First());
        Assert.True(result.Headers.Contains("Clerk-API-Version"));
    }

    [Fact]
    public async Task BeforeRequestAsync_WithNullOrigin_DoesNotAddOriginHeader()
    {
        // Arrange
        var hook = new ClerkBeforeRequestHook(null);
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.clerk.com/v1/sessions/123/tokens");
        var hookCtx = new BeforeRequestContext(new HookContext(
            new SDKConfig(),
            "https://api.clerk.com/v1",
            "CreateSessionToken",
            null,
            null
        ));

        // Act
        var result = await hook.BeforeRequestAsync(hookCtx, request);

        // Assert
        Assert.False(result.Headers.Contains("Origin"));
        Assert.True(result.Headers.Contains("Clerk-API-Version"));
    }

    [Fact]
    public async Task BeforeRequestAsync_WithEmptyOrigin_DoesNotAddOriginHeader()
    {
        // Arrange
        var hook = new ClerkBeforeRequestHook("");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.clerk.com/v1/sessions/123/tokens");
        var hookCtx = new BeforeRequestContext(new HookContext(
            new SDKConfig(),
            "https://api.clerk.com/v1",
            "CreateSessionToken",
            null,
            null
        ));

        // Act
        var result = await hook.BeforeRequestAsync(hookCtx, request);

        // Assert
        Assert.False(result.Headers.Contains("Origin"));
        Assert.True(result.Headers.Contains("Clerk-API-Version"));
    }
}