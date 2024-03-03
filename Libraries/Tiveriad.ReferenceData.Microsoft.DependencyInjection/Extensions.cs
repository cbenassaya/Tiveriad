#region

using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Commons.Extensions;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.ReferenceData.Apis.Controllers;
using Tiveriad.ReferenceData.Apis.Mappings;
using Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;
using Tiveriad.ReferenceData.Applications.Pipelines;

#endregion

namespace Tiveriad.ReferenceData.Microsoft.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddKeyValueServices(this IServiceCollection services, params Assembly[] assembliesToScan)
    {
        services
            .AddGenericControllers(assembliesToScan)
            .AddMediatR(cfg =>
            {
                cfg.Lifetime = ServiceLifetime.Scoped;
                cfg.RegisterServicesFromAssemblies(typeof(KeyValueSaveCommandHandler).Assembly);
            })
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>))
            .AddAutoMapper(typeof(KeyValueProfile).Assembly);
        return services;
    }

    private static IServiceCollection AddGenericControllers(this IServiceCollection services,
        params Assembly[] assembliesToScan)
    {
        services
            .AddControllers(o =>
            {
                o.Conventions.Add(
                    new ReferenceDataControllerRouteConvention()
                );
            })
            .ConfigureApplicationPartManager(m =>
            {
                m.FeatureProviders.Add(new ReferenceDataControllerFeatureProvider(assembliesToScan));
            });

        return services;
    }
}

