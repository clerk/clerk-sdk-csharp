namespace Clerk.BackendAPI.Hooks.Telemetry
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public interface ITelemetryCollector
    {
        void Collect(TelemetryEvent @event);
    }

    public abstract class BaseTelemetryCollector : ITelemetryCollector
    {
        protected readonly string Sdkv;
        protected readonly string Sdk;

        protected BaseTelemetryCollector()
        {
            var sdkInfo = SdkInfo.LoadFromAssembly();
            Sdkv = sdkInfo?.Version ?? "unknown";
            Sdk = sdkInfo != null ? $"{sdkInfo.GroupId}:{sdkInfo.Name}" : "csharp:unknown";
        }

        public void Collect(TelemetryEvent @event)
        {
            if (@event.It == "development")
            {
                CollectInternal(@event);
            }
        }

        protected virtual string SerializeToJson(PreparedEvent preparedEvent)
        {
            // Convert to sanitized dictionary with lowercase keys then serialize
            var sanitizedEvent = preparedEvent.Sanitize();
            return JsonSerializer.Serialize(sanitizedEvent);
        }

        protected PreparedEvent PrepareEvent(TelemetryEvent @event)
        {
            return new PreparedEvent(
                @event.Event,
                @event.It,
                Sdk,
                Sdkv,
                @event.Sk,
                new Dictionary<string, string>(@event.Payload)
            );
        }

        protected abstract void CollectInternal(TelemetryEvent @event);
    }

    public class DebugTelemetryCollector : BaseTelemetryCollector
    {
        protected override void CollectInternal(TelemetryEvent @event)
        {
            try
            {
                Console.Error.WriteLine(SerializeToJson(PrepareEvent(@event)));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to serialize event: {ex.Message}");
            }
        }
    }

    public class LiveTelemetryCollector : BaseTelemetryCollector
    {
        private const string Endpoint = "http://localhost:3000/";
        private readonly List<ITelemetrySampler> _samplers;
        private readonly HttpClient _httpClient;
        private static readonly object _consoleLock = new object();

        public LiveTelemetryCollector(List<ITelemetrySampler> samplers)
        {
            _samplers = samplers;
            _httpClient = new HttpClient();
        }

        protected override void CollectInternal(TelemetryEvent @event)
        {
            PreparedEvent preparedEvent = PrepareEvent(@event);
            foreach (var sampler in _samplers)
            {
                if (!sampler.shouldSample(preparedEvent, @event))
                {
                    return;
                }
            }

            Task.Run(() => SendEventAsync(@event));
        }

        private async Task SendEventAsync(TelemetryEvent @event)
        {
            try
            {
                PreparedEvent preparedEvent = PrepareEvent(@event);
                string eventJson = SerializeToJson(preparedEvent);
                
                var content = new StringContent(eventJson, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync(Endpoint, content);
                
                string responseContent = await response.Content.ReadAsStringAsync();
                
                if (!response.IsSuccessStatusCode)
                {
                    LogDebug($"Failed to send telemetry event. Response code: {(int)response.StatusCode}, error: {responseContent}");
                }
            }
            catch (Exception ex)
            {
                LogDebug($"Error sending telemetry event: {ex.Message}");
            }
        }
        private void LogDebug(string message)
        {
            // Only log in debug mode or controlled by environment variable
            if (Environment.GetEnvironmentVariable("CLERK_TELEMETRY_DEBUG") == "1")
            {
                lock (_consoleLock)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Error.WriteLine(message);
                    Console.ResetColor();
                }
            }
        }

        public static LiveTelemetryCollector Standard()
        {
            return new LiveTelemetryCollector(new List<ITelemetrySampler>
            {
                // RandomSampler.Standard(),
                DeduplicatingSampler.Standard()
            });
        }
    }
}