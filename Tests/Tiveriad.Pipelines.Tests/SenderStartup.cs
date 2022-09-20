using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Pipelines.Tests.Models;
using Tiveriad.UnitTests;

namespace Tiveriad.Pipelines.Tests;

public class SenderStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        services
            .AddScoped<IServiceResolver,
                ServiceResolver>();
        services
            .AddScoped<IRequestHandler<Request, int>,
                RequestHandler>();
        services
            .AddSingleton<ISender,Sender>();
    }
}



public class ServiceResolver : IServiceResolver
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public object Resolve(Type type)
    {
        return _serviceProvider.GetRequiredService(type);
    }
}