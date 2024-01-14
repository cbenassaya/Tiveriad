namespace Tiveriad.Cache;

/// <summary>
/// Used to build a <c>CacheHandleConfiguration</c>.
/// </summary>
/// <see cref="CacheManagerConfiguration"/>
public sealed class CacheHandleConfigurator
{
    //private CacheManagerConfigurator _parent;

    internal CacheHandleConfigurator(CacheHandleConfiguration cfg, CacheManagerConfigurator parentManagerConfigurator)
    {
        Configuration = cfg;
    }

    internal CacheHandleConfiguration Configuration { get; }

    /// <summary>
    /// Sets the expiration mode and timeout of the cache handle.
    /// </summary>
    /// <param name="expirationMode">The expiration mode.</param>
    /// <param name="timeout">The timeout.</param>
    /// <returns>The builder part.</returns>
    /// <exception cref="System.InvalidOperationException">
    /// If expiration mode is not set to 'None', timeout cannot be zero.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown if expiration mode is not 'None' and timeout is zero.
    /// </exception>
    /// <seealso cref="ExpirationMode"/>
    public CacheHandleConfigurator WithExpiration(ExpirationMode expirationMode,  TimeSpan timeout )
    {
        // fixed #192 (was missing check for "Default" mode)
        if (expirationMode != ExpirationMode.None && expirationMode != ExpirationMode.Default && timeout == TimeSpan.Zero)
        {
            throw new InvalidOperationException("If expiration mode is not set to 'None', timeout cannot be zero.");
        }

        Configuration.ExpirationMode = expirationMode;
        Configuration.ExpirationTimeout = timeout;
        return this;
    }
}