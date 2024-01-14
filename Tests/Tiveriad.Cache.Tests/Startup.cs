#region

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tiveriad.Cache;
using Tiveriad.Cache.Internal;
using Tiveriad.UnitTests;

#endregion

namespace Tiveriad.Commons.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services.AddSingleton<ICacheManagerConfiguration>((serviceProvider) =>
        {
            var configuration = ConfigurationBuilder.Create().Configure(configurator =>
            {
                configurator.WithJsonSerializer().WithDictionaryHandle()
                    .WithExpiration(ExpirationMode.None, TimeSpan.Zero);
            }).Build();
            return configuration;
        });
        services.AddSingleton<ICacheManager<object>,CacheManagerBase<object>>();
        services.AddLogging(config =>
        {
            config.SetMinimumLevel(LogLevel.Trace);
            config.AddConsole();
        });

    }
}