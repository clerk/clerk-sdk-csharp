using System;
using System.Collections.Generic;
using Clerk.BackendAPI.Hooks;
using Clerk.BackendAPI.Hooks.Telemetry;
using Clerk.BackendAPI.Utils;
using Xunit;

namespace Tests.Telemetry
{
    public class TelemetryEventTests
    {
        [Fact]
        public void Constructor_InitializesAllFields()
        {
            // Arrange
            string sk = "sk_test_123";
            string @event = TelemetryEvent.EVENT_METHOD_CALLED;
            var payload = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };
            float samplingRate = 0.5f;

            // Act
            var telemetryEvent = new TelemetryEvent(sk, @event, payload, samplingRate);

            // Assert
            Assert.Equal(sk, telemetryEvent.Sk);
            Assert.Equal("development", telemetryEvent.It);
            Assert.Equal(@event, telemetryEvent.Event);
            Assert.Equal(payload, telemetryEvent.Payload);
            Assert.Equal(samplingRate, telemetryEvent.SamplingRate);
        }

        [Theory]
        [InlineData("sk_test_123", "development")]
        [InlineData("sk_test_abc", "development")]
        [InlineData("sk_live_456", "production")]
        [InlineData("sk_123", "production")]
        [InlineData(null, "production")]
        public void Constructor_SetsItBasedOnSk(string sk, string expectedIt)
        {
            // Arrange & Act
            var telemetryEvent = new TelemetryEvent(
                sk,
                TelemetryEvent.EVENT_METHOD_CALLED,
                new Dictionary<string, string>(),
                0.5f
            );

            // Assert
            Assert.Equal(expectedIt, telemetryEvent.It);
        }

        [Fact]
        public void FromContext_EmptyAdditionalPayload()
        {
            // Arrange
            string operationId = "testOperation";
            var emptyPayload = new Dictionary<string, string>();
            float samplingRate = 0.1f;

            var context = new TestHookContext(operationId, null);

            // Act
            var @event = TelemetryEvent.FromContext(
                context,
                TelemetryEvent.EVENT_METHOD_CALLED,
                samplingRate,
                emptyPayload
            );

            // Assert
            Assert.Single(@event.Payload);
            Assert.Equal("testOperation", @event.Payload["method"]);
        }

        [Fact]
        public void FromContext_AdditionalPayloadOverridesMethod()
        {
            // Not so much behavior we desire as documentation that this occurs
            // Arrange
            string operationId = "testOperation";
            var overridingPayload = new Dictionary<string, string>
            {
                { "method", "overridden-method" }
            };
            float samplingRate = 0.5f;

            var context = new TestHookContext(operationId, null);

            // Act
            var @event = TelemetryEvent.FromContext(
                context,
                TelemetryEvent.EVENT_METHOD_CALLED,
                samplingRate,
                overridingPayload
            );

            // Assert
            Assert.Single(@event.Payload);
            Assert.Equal("overridden-method", @event.Payload["method"]);
        }

        // Test implementation for HookContext
        private class TestHookContext : HookContext
        {
            public TestHookContext(string operationId, Func<object> securitySource)
                : base(operationId, null, securitySource)
            {
            }
        }
    }
}