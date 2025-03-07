using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Clerk.BackendAPI.Hooks.Telemetry;
using Xunit;

namespace Tests.Telemetry
{
    public class TelemetryCollectorTests
    {
        [Fact]
        public void BaseCollector_CollectIgnoresProductionEvents()
        {
            // Arrange
            var prodEvent = new TelemetryEvent(
                "sk_live_123",
                TelemetryEvent.EVENT_METHOD_CALLED,
                new Dictionary<string, string> { { "method", "test-method" } },
                1.0f
            );

            var collector = new TestCollector();

            // Act
            collector.Collect(prodEvent);

            // Assert
            Assert.False(collector.WasCollectInternalCalled, "collectInternal should not be called for production events");
        }

        [Fact]
        public void BaseCollector_CollectCallsCollectInternalForDevelopment()
        {
            // Arrange
            var devEvent = new TelemetryEvent(
                "sk_test_123",
                TelemetryEvent.EVENT_METHOD_CALLED,
                new Dictionary<string, string> { { "method", "test-method" } },
                1.0f
            );

            var collector = new TestCollector();

            // Act
            collector.Collect(devEvent);

            // Assert
            Assert.True(collector.WasCollectInternalCalled, "collectInternal should be called for development events");
            Assert.Equal(devEvent, collector.LastEvent);
        }

        [Fact]
        public void BaseCollector_PrepareEventPopulatesAllFields()
        {
            // Arrange
            var event1 = new TelemetryEvent(
                "sk_test_123",
                TelemetryEvent.EVENT_METHOD_CALLED,
                new Dictionary<string, string> { { "key1", "value1" } },
                1.0f
            );

            var collector = new TestCollector();

            // Act
            PreparedEvent prepared = collector.PrepareEventForTest(event1);

            // Assert
            Assert.Equal(event1.Event, prepared.Event);
            Assert.Equal(event1.It, prepared.It);
            Assert.NotNull(prepared.Sdk);
            Assert.NotNull(prepared.Sdkv);
            Assert.Equal(event1.Sk, prepared.Sk);
            Assert.IsType<Dictionary<string, string>>(prepared.Payload);
            Assert.Equal("value1", prepared.Payload["key1"]);
        }
        
        [Fact]
        public void DebugCollector_OutputsToConsole()
        {
            // Arrange
            var event1 = new TelemetryEvent(
                "sk_test_123",
                TelemetryEvent.EVENT_METHOD_CALLED,
                new Dictionary<string, string> { { "method", "test-method" } },
                1.0f
            );

            var collector = new TestDebugCollector();
            var consoleOutput = new StringWriter();
            Console.SetError(consoleOutput);

            try
            {
                // Act
                collector.CollectInternalForTest(event1);

                // Assert
                string output = consoleOutput.ToString();
                Assert.Contains(collector.SerializedOutput, output);
            }
            finally
            {
                Console.SetError(Console.Error);
            }
        }

        [Fact]
        public void DebugCollector_HandlesSerializationError()
        {
            // Arrange
            var event1 = new TelemetryEvent(
                "sk_test_123",
                TelemetryEvent.EVENT_METHOD_CALLED,
                new Dictionary<string, string> { { "method", "test-method" } },
                1.0f
            );

            var collector = new TestDebugCollector { ThrowOnSerialize = true };
            var consoleOutput = new StringWriter();
            Console.SetError(consoleOutput);

            try
            {
                // Act
                collector.CollectInternalForTest(event1);

                // Assert
                string output = consoleOutput.ToString();
                Assert.Contains("Failed to serialize event", output);
            }
            finally
            {
                Console.SetError(Console.Error);
            }
        }

        // Helper test classes
        private class TestCollector : BaseTelemetryCollector
        {
            public bool WasCollectInternalCalled { get; private set; }
            public TelemetryEvent LastEvent { get; private set; }

            protected override void CollectInternal(TelemetryEvent @event)
            {
                WasCollectInternalCalled = true;
                LastEvent = @event;
            }

            public PreparedEvent PrepareEventForTest(TelemetryEvent @event)
            {
                return PrepareEvent(@event);
            }
        }

        private class TestDebugCollector : DebugTelemetryCollector
        {
            public bool ThrowOnSerialize { get; set; }
            public string SerializedOutput { get; } = "{\"test\":\"json\"}";

            protected override string SerializeToJson(PreparedEvent preparedEvent)
            {
                if (ThrowOnSerialize)
                {
                    throw new Exception("Test error");
                }
                return SerializedOutput;
            }

            public void CollectInternalForTest(TelemetryEvent @event)
            {
                CollectInternal(@event);
            }
        }
    }
}