using Tiveriad.Cache.Internal;
using Tiveriad.Cache.Utility;

namespace Tiveriad.Cache;

/// <summary>
/// Used to build a <c>CacheManagerConfiguration</c>.
/// </summary>
/// <see cref="CacheManagerConfiguration"/>
public class CacheManagerConfigurator
{
    internal CacheManagerConfigurator()
    {
        Configuration = new CacheManagerConfiguration();
    }

    internal CacheManagerConfigurator(CacheManagerConfiguration forConfiguration)
    {
        Guard.NotNull(forConfiguration, nameof(forConfiguration));
        Configuration = forConfiguration;
    }

    /// <summary>
    /// Gets the configuration.
    /// </summary>
    /// <value>The configuration.</value>
    internal CacheManagerConfiguration Configuration { get; }

    /// <summary>
    /// Configures the backplane for the cache manager.
    /// <para>
    /// This is an optional feature. If specified, see the documentation for the
    /// <paramref name="backplaneType"/>. The <paramref name="configurationKey"/> might be used to
    /// reference another configuration item.
    /// </para>
    /// <para>
    /// If a backplane is defined, at least one cache handle must be marked as backplane
    /// source. The cache manager then will try to synchronize multiple instances of the same configuration.
    /// </para>
    /// </summary>
    /// <param name="backplaneType">The type of the backplane implementation.</param>
    /// <param name="configurationKey">The name.</param>
    /// <param name="args">Additional arguments the type might need to get initialized.</param>
    /// <returns>The builder instance.</returns>
    /// <exception cref="System.ArgumentNullException">If <paramref name="configurationKey"/> is null.</exception>
    public CacheManagerConfigurator WithBackplane(Type backplaneType, string configurationKey, params object[] args)
    {
        Guard.NotNull(backplaneType, nameof(backplaneType));
        Guard.NotNullOrWhiteSpace(configurationKey, nameof(configurationKey));

        Configuration.BackplaneType = backplaneType;
        Configuration.BackplaneTypeArguments = args;
        Configuration.BackplaneConfigurationKey = configurationKey;
        return this;
    }

    /// <summary>
    /// Configures the backplane for the cache manager.
    /// <para>
    /// This is an optional feature. If specified, see the documentation for the
    /// <paramref name="backplaneType"/>. The <paramref name="configurationKey"/> might be used to
    /// reference another configuration item.
    /// </para>
    /// <para>
    /// If a backplane is defined, at least one cache handle must be marked as backplane
    /// source. The cache manager then will try to synchronize multiple instances of the same configuration.
    /// </para>
    /// </summary>
    /// <param name="backplaneType">The type of the backplane implementation.</param>
    /// <param name="configurationKey">The configuration key.</param>
    /// <param name="channelName">The backplane channel name.</param>
    /// <param name="args">Additional arguments the type might need to get initialized.</param>
    /// <returns>The builder instance.</returns>
    /// <exception cref="System.ArgumentNullException">
    /// If <paramref name="configurationKey"/> or <paramref name="channelName"/> is null.
    /// </exception>
    public CacheManagerConfigurator WithBackplane(Type backplaneType, string configurationKey, string channelName, params object[] args)
    {
        Guard.NotNull(backplaneType, nameof(backplaneType));
        Guard.NotNullOrWhiteSpace(configurationKey, nameof(configurationKey));
        Guard.NotNullOrWhiteSpace(channelName, nameof(channelName));

        Configuration.BackplaneType = backplaneType;
        Configuration.BackplaneTypeArguments = args;
        Configuration.BackplaneChannelName = channelName;
        Configuration.BackplaneConfigurationKey = configurationKey;
        return this;
    }

    /// <summary>
    /// Adds a cache dictionary cache handle to the cache manager.
    /// </summary>
    /// <param name="isBackplaneSource">
    /// Set this to true if this cache handle should be the source of the backplane.
    /// <para>This setting will be ignored if no backplane is configured.</para>
    /// </param>
    /// <returns>The builder part.</returns>
    public CacheHandleConfigurator WithDictionaryHandle(bool isBackplaneSource = false) =>
        WithHandle(typeof(DictionaryCacheHandle<>), Guid.NewGuid().ToString("N"), isBackplaneSource);

    /// <summary>
    /// Adds a cache dictionary cache handle to the cache manager.
    /// </summary>
    /// <returns>The builder part.</returns>
    /// <param name="handleName">The name of the cache handle.</param>
    /// <param name="isBackplaneSource">
    /// Set this to true if this cache handle should be the source of the backplane.
    /// <para>This setting will be ignored if no backplane is configured.</para>
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="handleName"/> is null.</exception>
    public CacheHandleConfigurator WithDictionaryHandle(string handleName, bool isBackplaneSource = false) =>
        WithHandle(typeof(DictionaryCacheHandle<>), handleName, isBackplaneSource);

    /// <summary>
    /// Adds a cache handle with the given <c>Type</c> and name.
    /// The type must be an open generic.
    /// </summary>
    /// <param name="cacheHandleBaseType">The cache handle type.</param>
    /// <param name="handleName">The name to be used for the cache handle.</param>
    /// <param name="isBackplaneSource">
    /// Set this to true if this cache handle should be the source of the backplane.
    /// <para>This setting will be ignored if no backplane is configured.</para>
    /// </param>
    /// <param name="configurationTypes">Internally used only.</param>
    /// <returns>The builder part.</returns>
    /// <exception cref="System.ArgumentNullException">If handleName is null.</exception>
    /// <exception cref="System.InvalidOperationException">
    /// Only one cache handle can be the backplane's source.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown if handleName or cacheHandleBaseType are null.
    /// </exception>
    public CacheHandleConfigurator WithHandle(Type cacheHandleBaseType, string handleName, bool isBackplaneSource, params object[] configurationTypes)
    {
        Guard.NotNull(cacheHandleBaseType, nameof(cacheHandleBaseType));
        Guard.NotNullOrWhiteSpace(handleName, nameof(handleName));

        var handleCfg = new CacheHandleConfiguration(handleName)
        {
            HandleType = cacheHandleBaseType,
            ConfigurationTypes = configurationTypes
        };

        handleCfg.IsBackplaneSource = isBackplaneSource;

        if (isBackplaneSource && Configuration.CacheHandleConfigurations.Any(p => p.IsBackplaneSource))
        {
            throw new InvalidOperationException("Only one cache handle can be the backplane's source.");
        }

        Configuration.CacheHandleConfigurations.Add(handleCfg);
        var part = new CacheHandleConfigurator(handleCfg, this);
        return part;
    }

    /// <summary>
    /// Adds a cache handle with the given <c>Type</c> and name.
    /// The type must be an open generic.
    /// </summary>
    /// <param name="cacheHandleBaseType">The cache handle type.</param>
    /// <param name="handleName">The name to be used for the cache handle.</param>
    /// <returns>The builder part.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if handleName or cacheHandleBaseType are null.
    /// </exception>
    public CacheHandleConfigurator WithHandle(Type cacheHandleBaseType, string handleName)
        => WithHandle(cacheHandleBaseType, handleName, false);

    /// <summary>
    /// Adds a cache handle with the given <c>Type</c>.
    /// The type must be an open generic.
    /// </summary>
    /// <param name="cacheHandleBaseType">The cache handle type.</param>
    /// <returns>The builder part.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if handleName or cacheHandleBaseType are null.
    /// </exception>
    public CacheHandleConfigurator WithHandle(Type cacheHandleBaseType)
        => WithHandle(cacheHandleBaseType, Guid.NewGuid().ToString("N"), false);

    /// <summary>
    /// Sets the maximum number of retries per action.
    /// <para>Default is 50.</para>
    /// <para>
    /// Not every cache handle implements this, usually only distributed caches will use it.
    /// </para>
    /// </summary>
    /// <param name="retries">The maximum number of retries.</param>
    /// <returns>The configuration builder.</returns>
    /// <exception cref="System.InvalidOperationException">
    /// Maximum number of retries must be greater than 0.
    /// </exception>
    public CacheManagerConfigurator WithMaxRetries(int retries)
    {
        Guard.Ensure(retries > 0, "Maximum number of retries must be greater than 0.");

        Configuration.MaxRetries = retries;
        return this;
    }

    /// <summary>
    /// Sets the timeout between each retry of an action in milliseconds.
    /// <para>Default is 100.</para>
    /// <para>
    /// Not every cache handle implements this, usually only distributed caches will use it.
    /// </para>
    /// </summary>
    /// <param name="timeoutMillis">The timeout in milliseconds.</param>
    /// <returns>The configuration builder.</returns>
    /// <exception cref="System.InvalidOperationException">
    /// Retry timeout must be greater than or equal to zero.
    /// </exception>
    public CacheManagerConfigurator WithRetryTimeout(int timeoutMillis)
    {
        Guard.Ensure(timeoutMillis >= 0, "Retry timeout must be greater than or equal to zero.");

        Configuration.RetryTimeout = timeoutMillis;
        return this;
    }

    /// <summary>
    /// Sets the update mode of the cache.
    /// <para>If nothing is set, the default will be <c>CacheUpdateMode.None</c>.</para>
    /// </summary>
    /// <param name="updateMode">The update mode.</param>
    /// <returns>The builder part.</returns>
    /// <seealso cref="CacheUpdateMode"/>
    public CacheManagerConfigurator WithUpdateMode(CacheUpdateMode updateMode)
    {
        Configuration.UpdateMode = updateMode;
        return this;
    }

    /// <summary>
    /// Sets the serializer which should be used to serialize cache items.
    /// </summary>
    /// <param name="serializerType">The type of the serializer.</param>
    /// <param name="args">Additional arguments the type might need to get initialized.</param>
    /// <returns>The builder part.</returns>
    public CacheManagerConfigurator WithSerializer(Type serializerType, params object[] args)
    {
        Guard.NotNull(serializerType, nameof(serializerType));

        Configuration.SerializerType = serializerType;
        Configuration.SerializerTypeArguments = args;
        return this;
    }


    /// <summary>
    /// Configures a <see cref="JsonCacheSerializer"/> to be used for serialization and deserialization.
    /// </summary>
    /// <returns>The builder part.</returns>
    public CacheManagerConfigurator WithJsonSerializer()
    {
        Configuration.SerializerType = typeof(JsonCacheSerializer);
        return this;
    }


    /// <summary>
    /// Hands back the new <see cref="CacheManagerConfiguration"/> instance.
    /// </summary>
    /// <returns>The <see cref="ICacheManagerConfiguration"/>.</returns>
    public ICacheManagerConfiguration Build()
    {
        return Configuration;
    }
}