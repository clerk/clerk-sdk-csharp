using System;
using System.Collections.Generic;
using Clerk.BackendAPI.Hooks.Telemetry;
using Xunit;

namespace Tests.Telemetry
{
    public class TelemetrySamplerTests
    {
        private static TelemetryEvent CreateTestEvent(float samplingRate)
        {
            return new TelemetryEvent(
                "sk_test_123",
                TelemetryEvent.EVENT_METHOD_CALLED,
                new Dictionary<string, string> { { "method", "test-method" } },
                samplingRate
            );
        }

        private static PreparedEvent CreateTestPreparedEvent(TelemetryEvent @event)
        {
            return new PreparedEvent(@event.Event, @event.It, "sdk", "sdkv", @event.Sk, @event.Payload);
        }

        [Fact]
        public void RandomSampler_WithSeedWorks()
        {
            // Arrange
            var fixedRandom = new Random(1);
            var sampler = new RandomSampler(fixedRandom);

            var @event = CreateTestEvent(0.5f);
            var preparedEvent = CreateTestPreparedEvent(@event);

            // Act - with a fixed seed, we should get deterministic results
            bool firstResult = sampler.Test(preparedEvent, @event);
            bool secondResult = sampler.Test(preparedEvent, @event);

            // The exact results will depend on the random seed, but we can at least verify they're different
            // With seed 1, these should be predictable
            Assert.NotEqual(firstResult, secondResult);
        }

        [Fact]
        public void RandomSampler_SamplingRateZero_AlwaysFalse()
        {
            // Arrange
            var sampler = new RandomSampler(new Random());

            // Act & Assert
            for (int i = 0; i < 100; i++)
            {
                var @event = CreateTestEvent(0.0f);
                var preparedEvent = CreateTestPreparedEvent(@event);
                Assert.False(sampler.Test(preparedEvent, @event), "Should always return false with 0.0 sampling rate");
            }
        }

        [Fact]
        public void RandomSampler_SamplingRateOne_AlwaysTrue()
        {
            // Arrange
            var sampler = new RandomSampler(new Random());


            // Act & Assert
            for (int i = 0; i < 100; i++)
            {
                var @event = CreateTestEvent(1.0f);
                var preparedEvent = CreateTestPreparedEvent(@event);
                Assert.True(sampler.Test(preparedEvent, @event), "Should always return true with 1.0 sampling rate");
            }
        }

        [Fact]
        public void DeduplicatingSampler_FirstEventAccepted()
        {
            // Arrange
            DateTime fixedTime = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            var sampler = new DeduplicatingSampler(
                TimeSpan.FromDays(1),
                () => fixedTime
            );

            var @event = CreateTestEvent(0.5f);
            var preparedEvent = CreateTestPreparedEvent(@event);

            // Act & Assert
            Assert.True(sampler.Test(preparedEvent, @event), "First event should be accepted");
        }

        [Fact]
        public void DeduplicatingSampler_DuplicateEventWithinWindowRejected()
        {
            // Arrange
            var testClock = new TestClock(new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc));
            var sampler = new DeduplicatingSampler(
                TimeSpan.FromDays(1),
                testClock.GetCurrentTime
            );

            var @event = CreateTestEvent(0.5f);
            var preparedEvent = CreateTestPreparedEvent(@event);

            // Act
            bool firstResult = sampler.Test(preparedEvent, @event);

            // Move time forward, but still within window
            testClock.SetCurrentTime(testClock.CurrentTime.AddHours(23));

            bool secondResult = sampler.Test(preparedEvent, @event);

            // Assert
            Assert.True(firstResult, "First event should be accepted");
            Assert.False(secondResult, "Duplicate event within window should be rejected");
        }

        [Fact]
        public void DeduplicatingSampler_EventAfterWindowAccepted()
        {
            // Arrange
            var testClock = new TestClock(new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc));
            var sampler = new DeduplicatingSampler(
                TimeSpan.FromDays(1),
                testClock.GetCurrentTime
            );

            var @event = CreateTestEvent(0.5f);
            var preparedEvent = CreateTestPreparedEvent(@event);

            // Act
            bool firstResult = sampler.Test(preparedEvent, @event);

            // Move time forward beyond window
            testClock.SetCurrentTime(testClock.CurrentTime.AddHours(25));

            bool secondResult = sampler.Test(preparedEvent, @event);

            // Assert
            Assert.True(firstResult, "First event should be accepted");
            Assert.True(secondResult, "Event after window should be accepted");
        }

        [Fact]
        public void DeduplicatingSampler_DifferentEventsAccepted()
        {
            // Arrange
            DateTime fixedTime = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc);
            var sampler = new DeduplicatingSampler(
                TimeSpan.FromDays(1),
                () => fixedTime
            );

            var firstEvent = new TelemetryEvent(
                "sk_test_123",
                TelemetryEvent.EVENT_METHOD_CALLED,
                new Dictionary<string, string> { { "method", "test-method-1" } },
                0.5f
            );
            var firstPreparedEvent = CreateTestPreparedEvent(firstEvent);

            var secondEvent = new TelemetryEvent(
                "sk_test_123",
                TelemetryEvent.EVENT_METHOD_CALLED,
                new Dictionary<string, string> { { "method", "test-method-2" } },
                0.5f
            );
            var secondPreparedEvent = CreateTestPreparedEvent(secondEvent);

            // Act
            bool firstResult = sampler.Test(firstPreparedEvent, firstEvent);
            bool secondResult = sampler.Test(secondPreparedEvent, secondEvent);

            // Assert
            Assert.True(firstResult, "First event should be accepted");
            Assert.True(secondResult, "Different event should be accepted");
        }

        // A test clock implementation that allows changing the time
        private class TestClock
        {
            public DateTime CurrentTime { get; private set; }

            public TestClock(DateTime initialTime)
            {
                CurrentTime = initialTime;
            }

            public void SetCurrentTime(DateTime newTime)
            {
                CurrentTime = newTime;
            }

            public DateTime GetCurrentTime()
            {
                return CurrentTime;
            }
        }
    }
}