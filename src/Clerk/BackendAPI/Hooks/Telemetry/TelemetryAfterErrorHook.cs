namespace Clerk.BackendAPI.Hooks.Telemetry
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class TelemetryAfterErrorHook : IAfterErrorHook
    {
        // Visible for testing
        public readonly List<ITelemetryCollector> Collectors;

        public TelemetryAfterErrorHook(List<ITelemetryCollector> collectors)
        {
            Collectors = collectors;
        }

        public Task<(HttpResponseMessage?, Exception?)> AfterErrorAsync(AfterErrorContext context, HttpResponseMessage? response, Exception? error)
        {
            var additionalPayload = new Dictionary<string, string>();
            
            if (response != null)
            {
                additionalPayload["status_code"] = ((int)response.StatusCode).ToString();
            }
            
            if (error != null)
            {
                additionalPayload["error_message"] = error.Message;
            }

            TelemetryEvent @event = TelemetryEvent.FromContext(
                context,
                TelemetryEvent.EVENT_METHOD_FAILED,
                0.1f,
                additionalPayload
            );

            foreach (var collector in Collectors)
            {
                collector.Collect(@event);
            }

            return Task.FromResult((response, error));
        }
    }
}