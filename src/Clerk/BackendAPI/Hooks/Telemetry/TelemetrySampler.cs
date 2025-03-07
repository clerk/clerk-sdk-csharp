namespace Clerk.BackendAPI.Hooks.Telemetry
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    public interface ITelemetrySampler
    {
        bool shouldSample(PreparedEvent preparedEvent, TelemetryEvent telemetryEvent);
    }

    public class RandomSampler : ITelemetrySampler
    {
        private readonly Random _random;

        public RandomSampler(Random random)
        {
            _random = random;
        }

        public bool shouldSample(PreparedEvent preparedEvent, TelemetryEvent telemetryEvent)
        {
            return _random.NextDouble() < telemetryEvent.SamplingRate;
        }

        public static RandomSampler Standard()
        {
            return new RandomSampler(new Random(1));
        }
    }

    public class DeduplicatingSampler : ITelemetrySampler
    {
        private readonly Dictionary<string, DateTime> _cache = new Dictionary<string, DateTime>();
        private readonly TimeSpan _window;
        private readonly Func<DateTime> _nowProvider;

        public DeduplicatingSampler(TimeSpan window, Func<DateTime> nowProvider)
        {
            _window = window;
            _nowProvider = nowProvider;
        }

        public bool shouldSample(PreparedEvent preparedEvent, TelemetryEvent telemetryEvent)
        {
            try
            {
                string key = JsonSerializer.Serialize(preparedEvent.Sanitize());
                DateTime now = _nowProvider();

                if (!_cache.TryGetValue(key, out DateTime lastSampled) || now - lastSampled > _window)
                {
                    _cache[key] = now;
                    return true;
                }
            }
            catch
            {
                // Ignore serialization errors
            }
            return false;
        }

        public static DeduplicatingSampler Standard()
        {
            return new DeduplicatingSampler(TimeSpan.FromDays(1), () => DateTime.UtcNow);
        }
    }
}