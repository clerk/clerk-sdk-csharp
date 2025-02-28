namespace Clerk.BackendAPI.Hooks
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ClerkBeforeRequestHook : IBeforeRequestHook
    {
        public async Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            request.Headers.Add("Clerk-API-Version", "2024-10-01");
            return request;
        }
    }
}