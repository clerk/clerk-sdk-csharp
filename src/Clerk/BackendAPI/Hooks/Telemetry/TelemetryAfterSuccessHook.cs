namespace Clerk.BackendAPI.Hooks.Telemetry
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class TelemetryAfterSuccessHook : IAfterSuccessHook
    {
        // Visible for testing
        public readonly List<ITelemetryCollector> Collectors;

        public TelemetryAfterSuccessHook(List<ITelemetryCollector> collectors)
        {
            Collectors = collectors;
        }

        public Task<HttpResponseMessage> AfterSuccessAsync(AfterSuccessContext context, HttpResponseMessage response)
        {
            var additionalPayload = new Dictionary<string, string>
            {
                ["status_code"] = ((int)response.StatusCode).ToString()
            };

            TelemetryEvent @event = TelemetryEvent.FromContext(
                context,
                TelemetryEvent.EVENT_METHOD_SUCCEEDED,
                0.1f,
                additionalPayload
            );

            foreach (var collector in Collectors)
            {
                collector.Collect(@event);
            }

            return Task.FromResult(response);
        }
    }
}