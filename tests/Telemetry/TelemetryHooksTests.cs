using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Clerk.BackendAPI.Hooks;
using Clerk.BackendAPI.Hooks.Telemetry;
using Xunit;

namespace Tests.Telemetry
{
    public class TelemetryHooksTests
    {
        [Fact]
        public async Task TelemetryBeforeRequestHook_CollectsEvent()
        {
            // Arrange
            var collector = new TestCollector();
            var hook = new TelemetryBeforeRequestHook(new List<ITelemetryCollector> { collector });
            
            var context = new BeforeRequestContext(new HookContext("testOperation", null, null));
            var request = new HttpRequestMessage(HttpMethod.Get, "https://example.com");

            // Act
            await hook.BeforeRequestAsync(context, request);

            // Assert
            Assert.Equal(1, collector.Events.Count);
            Assert.Equal(TelemetryEvent.EVENT_METHOD_CALLED, collector.Events[0].Event);
            Assert.Equal("testOperation", collector.Events[0].Payload["method"]);
        }

        [Fact]
        public async Task TelemetryAfterSuccessHook_CollectsEventWithStatusCode()
        {
            // Arrange
            var collector = new TestCollector();
            var hook = new TelemetryAfterSuccessHook(new List<ITelemetryCollector> { collector });
            
            var context = new AfterSuccessContext(new HookContext("testOperation", null, null));
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            // Act
            await hook.AfterSuccessAsync(context, response);

            // Assert
            Assert.Equal(1, collector.Events.Count);
            Assert.Equal(TelemetryEvent.EVENT_METHOD_SUCCEEDED, collector.Events[0].Event);
            Assert.Equal("testOperation", collector.Events[0].Payload["method"]);
            Assert.Equal("200", collector.Events[0].Payload["status_code"]);
        }

        [Fact]
        public async Task TelemetryAfterErrorHook_CollectsEventWithStatusCode()
        {
            // Arrange
            var collector = new TestCollector();
            var hook = new TelemetryAfterErrorHook(new List<ITelemetryCollector> { collector });
            
            var context = new AfterErrorContext(new HookContext("testOperation", null, null));
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

            // Act
            await hook.AfterErrorAsync(context, response, null);

            // Assert
            Assert.Equal(1, collector.Events.Count);
            Assert.Equal(TelemetryEvent.EVENT_METHOD_FAILED, collector.Events[0].Event);
            Assert.Equal("testOperation", collector.Events[0].Payload["method"]);
            Assert.Equal("400", collector.Events[0].Payload["status_code"]);
        }

        [Fact]
        public async Task TelemetryAfterErrorHook_CollectsEventWithErrorMessage()
        {
            // Arrange
            var collector = new TestCollector();
            var hook = new TelemetryAfterErrorHook(new List<ITelemetryCollector> { collector });
            
            var context = new AfterErrorContext(new HookContext("testOperation", null, null));
            var error = new Exception("Test error message");

            // Act
            await hook.AfterErrorAsync(context, null, error);

            // Assert
            Assert.Equal(1, collector.Events.Count);
            Assert.Equal(TelemetryEvent.EVENT_METHOD_FAILED, collector.Events[0].Event);
            Assert.Equal("testOperation", collector.Events[0].Payload["method"]);
            Assert.Equal("Test error message", collector.Events[0].Payload["error_message"]);
        }

        // Helper test class
        private class TestCollector : ITelemetryCollector
        {
            public List<TelemetryEvent> Events { get; } = new List<TelemetryEvent>();

            public void Collect(TelemetryEvent @event)
            {
                Events.Add(@event);
            }
        }
    }
}