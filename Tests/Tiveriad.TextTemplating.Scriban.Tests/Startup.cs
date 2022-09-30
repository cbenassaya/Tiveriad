using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Commons.Extensions;
using Tiveriad.UnitTests;

namespace Tiveriad.TextTemplating.Scriban.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        TemplateRendererFactoryBuilder
            .With<ScribanTemplateRenderer, ScribanTemplateRendererConfiguration>()
            .Add(typeof(Startup).Assembly)
            .Configure(configuration =>
            {
                configuration.Add(typeof(StringExtensions));
            })
            .Register(renderer =>
            {
                services.AddSingleton<ITemplateRenderer>(renderer);
            });

        
    }
}