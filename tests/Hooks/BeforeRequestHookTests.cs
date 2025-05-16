using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Clerk.BackendAPI.Hooks;
using Xunit;

public class ClerkBeforeRequestHookTests
{
    [Fact]
    public async Task BeforeRequestAsync_AddsClerkApiVersionHeader()
    {
        var hook = new ClerkBeforeRequestHook();
        var request = new HttpRequestMessage();
        var hookCtx = new BeforeRequestContext(new HookContext("test", null, null, null));

        var result = await hook.BeforeRequestAsync(hookCtx, request);


        Assert.True(result.Headers.Contains("Clerk-API-Version"));
        Assert.Equal("2024-10-01", result.Headers.GetValues("Clerk-API-Version").First());
    }
}