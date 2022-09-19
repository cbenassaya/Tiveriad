using Microsoft.Extensions.DependencyInjection;
using Tiveriad.UnitTests;

namespace Tiveriad.TextTemplating.Scriban.Tests;

public class Startup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        ITemplateFactory<ScribanTemplateRenderer> factory = new TemplateFactory<ScribanTemplateRenderer>();
        factory.Add(this.GetType().Assembly);
        services.AddSingleton<ITemplateRenderer>(factory.Build());
    }
}