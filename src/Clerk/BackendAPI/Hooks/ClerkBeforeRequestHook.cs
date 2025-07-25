namespace Clerk.BackendAPI.Hooks
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ClerkBeforeRequestHook : IBeforeRequestHook
    {
        private readonly string? _origin;

        /// <summary>
        /// Initializes a new instance of the ClerkBeforeRequestHook.
        /// </summary>
        public ClerkBeforeRequestHook() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ClerkBeforeRequestHook with the specified origin.
        /// This ensures that session tokens include the azp (authorized parties) claim.
        /// </summary>
        /// <param name="origin">The origin URL (e.g., "https://example.com") to be included in the azp claim.</param>
        public ClerkBeforeRequestHook(string? origin)
        {
            _origin = origin;
        }

        public async Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            // Add the Clerk API version header
            request.Headers.Add("Clerk-API-Version", "2024-10-01");

            // Add Origin header for session token creation operations if origin is specified
            if (!string.IsNullOrEmpty(_origin) &&
                (hookCtx.OperationID == "CreateSessionToken" || hookCtx.OperationID == "CreateSessionTokenFromTemplate"))
            {
                if (!request.Headers.Contains("Origin"))
                {
                    request.Headers.Add("Origin", _origin);
                }
            }

            await Task.CompletedTask;
            return request;
        }
    }
}
