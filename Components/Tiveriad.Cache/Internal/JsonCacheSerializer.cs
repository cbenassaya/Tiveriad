#if !NETSTANDARD2

#region

using System.Text.Json;

#endregion

namespace Tiveriad.Cache.Internal
{
    /// <summary>
    ///     Basic binary serialization implementation of the <see cref="ICacheSerializer" />.
    ///     This implementation will be used in case no other serializer is configured for the cache manager
    ///     and serialization is needed (only distributed caches will have to serialize the cache value).
    ///     Binary serialization will not be available in some environments.
    /// </summary>
    public class JsonCacheSerializer : ICacheSerializer
    {
        /// <inheritdoc />
        public object? Deserialize(byte[] data, Type target)
        {
            if (data == null)
                return null;
            return JsonSerializer.Deserialize(new ReadOnlySpan<byte>(data), target);
        }

        /// <inheritdoc />
        public CacheItem<T>? DeserializeCacheItem<T>(byte[] value, Type valueType)
        {
            return (CacheItem<T>)Deserialize(value, valueType)!;
        }

        /// <inheritdoc />
        public byte[] Serialize<T>(T value)
        {
            if (value == null) return null;

            return JsonSerializer.SerializeToUtf8Bytes(value,
                new JsonSerializerOptions { WriteIndented = false, IgnoreNullValues = true });
        }

        /// <inheritdoc />
        public byte[] SerializeCacheItem<T>(CacheItem<T> value)
        {
            return Serialize(value);
        }
    }
}
#endif