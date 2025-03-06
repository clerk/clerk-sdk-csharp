namespace Clerk.BackendAPI.Hooks.Telemetry
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text.Json;
    using Clerk.BackendAPI.Models.Components;

    public class TelemetryEvent
    {
        public const string EVENT_METHOD_CALLED = "METHOD_CALLED";
        public const string EVENT_METHOD_SUCCEEDED = "METHOD_SUCCEEDED";
        public const string EVENT_METHOD_FAILED = "METHOD_FAILED";

        public string Sk { get; }
        public string It { get; }
        public string Event { get; }
        public Dictionary<string, string> Payload { get; }
        public float SamplingRate { get; }

        public TelemetryEvent(
            string sk,
            string @event,
            Dictionary<string, string> payload,
            float samplingRate)
        {
            Sk = sk;
            It = sk != null && sk.StartsWith("sk_test") ? "development" : "production";
            Event = @event;
            Payload = payload;
            SamplingRate = samplingRate;
        }

        public static TelemetryEvent FromContext(
            HookContext ctx,
            string @event,
            float samplingRate,
            Dictionary<string, string> additionalPayload)
        {
            string sk = "unknown";
            
            // Extract bearer token from security source if available
            if (ctx.SecuritySource != null)
            {
                var securitySource = ctx.SecuritySource();
                Security? securityObj = securitySource is Security ? (Security)securitySource : null;
                sk = securityObj?.BearerAuth ?? "unknown";
            }

            var payload = new Dictionary<string, string>
            {
                ["method"] = ctx.OperationID
            };

            foreach (var item in additionalPayload)
            {
                payload[item.Key] = item.Value;
            }

            return new TelemetryEvent(
                sk,
                @event,
                payload,
                samplingRate
            );
        }
    }
}