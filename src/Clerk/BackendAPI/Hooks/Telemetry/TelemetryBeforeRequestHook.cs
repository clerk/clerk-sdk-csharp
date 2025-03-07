namespace Clerk.BackendAPI.Hooks.Telemetry
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class TelemetryBeforeRequestHook : IBeforeRequestHook
    {
        // Visible for testing
        public readonly List<ITelemetryCollector> Collectors;

        public TelemetryBeforeRequestHook(List<ITelemetryCollector> collectors)
        {
            Collectors = collectors;
        }

        public Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext context, HttpRequestMessage request)
        {
            TelemetryEvent @event = TelemetryEvent.FromContext(
                context,
                TelemetryEvent.EVENT_METHOD_CALLED,
                0.1f,
                new Dictionary<string, string>()
            );

            foreach (var collector in Collectors)
            {
                collector.Collect(@event);
            }

            return Task.FromResult(request);
        }
    }
}