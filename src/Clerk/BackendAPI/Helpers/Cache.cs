using System;
using System.Collections.Generic;

namespace Clerk.BackendAPI.Helpers.Jwks;

/// <summary>
/// In-memory cache with expiration.
/// </summary>
public class Cache
{
    private readonly Dictionary<string, CacheEntry> _cache = new Dictionary<string, CacheEntry>();
    private readonly int _expirationTimeSeconds = 300; // 5 minutes

    private class CacheEntry
    {
        public string Value { get; set; }
        public DateTime Expiration { get; set; }

        public CacheEntry(string value, DateTime expiration)
        {
            Value = value;
            Expiration = expiration;
        }
    }

    /// <summary>
    /// Stores a value in the cache with an expiration time.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <param name="value">The value to cache.</param>
    public void Set(string? key, string value)
    {
        if (key == null)
            return;

        var expiration = DateTime.UtcNow.AddSeconds(_expirationTimeSeconds);
        _cache[key] = new CacheEntry(value, expiration);
    }

    /// <summary>
    /// Retrieves a value from the cache if it exists and has not expired.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <returns>The cached value, or null if not found or expired.</returns>
    public string? Get(string? key)
    {
        if (key == null)
            return null;

        if (_cache.TryGetValue(key, out var entry))
        {
            if (DateTime.UtcNow < entry.Expiration)
            {
                return entry.Value;
            }

            // Expired, remove from cache
            _cache.Remove(key);
        }

        return null;
    }
}
