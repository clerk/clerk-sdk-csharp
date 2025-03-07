using System.Collections.Generic;
using Clerk.BackendAPI.Hooks.Telemetry;
using Xunit;

namespace Tests.Telemetry
{
    public class PreparedEventTests
    {
        [Fact]
        public void Sanitize_ContainsAllFields()
        {
            // Arrange
            string @event = "test-event";
            string it = "test-it";
            string sdk = "csharp";
            string sdkv = "1.0.0";
            string sk = "sk_test_123";
            var payload = new Dictionary<string, string> 
            {
                { "key1", "value1" }, 
                { "key2", "value2" }
            };

            var preparedEvent = new PreparedEvent(@event, it, sdk, sdkv, sk, payload);

            // Act
            var sanitized = preparedEvent.Sanitize();

            // Assert
            Assert.Equal(@event, sanitized["event"]);
            Assert.Equal(it, sanitized["it"]);
            Assert.Equal(sdk, sanitized["sdk"]);
            Assert.Equal(sdkv, sanitized["sdkv"]);
            Assert.Equal("value1", sanitized["key1"]);
            Assert.Equal("value2", sanitized["key2"]);
        }

        [Fact]
        public void Sanitize_DoesNotIncludeSk()
        {
            // Arrange
            var preparedEvent = new PreparedEvent(
                "test-event",
                "test-it",
                "csharp",
                "1.0.0",
                "sk_test_123",
                new Dictionary<string, string>()
            );

            // Act
            var sanitized = preparedEvent.Sanitize();

            // Assert
            Assert.False(sanitized.ContainsKey("sk"), "SK should not be included in sanitized output");
        }

        [Fact]
        public void Sanitize_PayloadOverridesDefaultFields()
        {
            // This is a negative test
            // It's not that we want this behavior so much as we want to document it
            // Arrange
            var payload = new Dictionary<string, string>
            {
                { "event", "overridden-event" },
                { "sdk", "overridden-sdk" }
            };

            var preparedEvent = new PreparedEvent(
                "original-event",
                "test-it",
                "original-sdk",
                "1.0.0",
                "sk_test_123",
                payload
            );

            // Act
            var sanitized = preparedEvent.Sanitize();

            // Assert
            Assert.Equal("overridden-event", sanitized["event"]);
            Assert.Equal("overridden-sdk", sanitized["sdk"]);
        }

        [Fact]
        public void Sanitize_HandlesEmptyPayload()
        {
            // Arrange
            var preparedEvent = new PreparedEvent(
                "test-event",
                "test-it",
                "csharp",
                "1.0.0",
                "sk_test_123",
                new Dictionary<string, string>()
            );

            // Act
            var sanitized = preparedEvent.Sanitize();

            // Assert
            Assert.Equal(4, sanitized.Count);
            Assert.Equal("test-event", sanitized["event"]);
            Assert.Equal("test-it", sanitized["it"]);
            Assert.Equal("csharp", sanitized["sdk"]);
            Assert.Equal("1.0.0", sanitized["sdkv"]);
        }

        [Fact]
        public void Sanitize_SortsKeys()
        {
            // Arrange
            var payload = new Dictionary<string, string>
            {
                { "z-key", "z-value" },
                { "a-key", "a-value" },
                { "m-key", "m-value" }
            };

            var preparedEvent = new PreparedEvent(
                "test-event",
                "test-it",
                "csharp",
                "1.0.0",
                "sk_test_123",
                payload
            );

            // Act
            var sanitized = preparedEvent.Sanitize();

            // Assert
            // SortedDictionary sorts keys alphabetically
            var expectedOrder = new[] { "a-key", "event", "it", "m-key", "sdk", "sdkv", "z-key" };
            var actualKeys = new string[sanitized.Count];
            sanitized.Keys.CopyTo(actualKeys, 0);

            Assert.Equal(expectedOrder, actualKeys);
        }
    }
}