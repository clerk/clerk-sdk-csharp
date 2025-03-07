namespace Clerk.BackendAPI.Hooks.Telemetry
{
    using System.Collections.Generic;

    public class PreparedEvent
    {
        public string Event { get; }
        public string It { get; }
        public string Sdk { get; }
        public string Sdkv { get; }
        public string Sk { get; }
        public Dictionary<string, string> Payload { get; }

        public PreparedEvent(string @event, string it, string sdk, string sdkv, string sk, Dictionary<string, string> payload)
        {
            Event = @event;
            It = it;
            Sdk = sdk;
            Sdkv = sdkv;
            Sk = sk;
            Payload = payload;
        }

        public SortedDictionary<string, string> Sanitize()
        {
            var sanitizedEvent = new SortedDictionary<string, string>
            {
                ["event"] = Event,
                ["it"] = It,
                ["sdk"] = Sdk,
                ["sdkv"] = Sdkv
            };

            foreach (var item in Payload)
            {
                sanitizedEvent[item.Key] = item.Value;
            }

            return sanitizedEvent;
        }
    }
}