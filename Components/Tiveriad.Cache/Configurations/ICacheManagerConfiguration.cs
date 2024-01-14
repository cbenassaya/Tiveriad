#region

#endregion

using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Extensions.Logging;

namespace Tiveriad.Cache;

/// <summary>
///     The writable configuration contract used primarrily internal only
/// </summary>
public interface ICacheManagerConfiguration : IReadOnlyCacheManagerConfiguration
{
    /// <summary>
    ///     Gets the list of cache handle configurations.
    /// </summary>
    /// <value>The list of cache handle configurations.</value>
    IList<CacheHandleConfiguration> CacheHandleConfigurations { get; }
}