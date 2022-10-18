using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tiveriad.Commons.Extensions;

namespace Tiveriad.Pipelines.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTiveriadSender(this IServiceCollection services,
        params Assembly[] assembliesToScan)
    {
        if (!assembliesToScan.Any())
            throw new ArgumentException(
                "No assemblies found to scan. Supply at least one assembly to scan for handlers.");

        var assembliesToScanArray = assembliesToScan ?? Array.Empty<Assembly>().ToArray();

        var openTypes = new[]
        {
            typeof(IRequest<>),
            typeof(IRequestHandler<,>)
        };

        foreach (var openInterface in openTypes) RegisterFor(openInterface, services, assembliesToScanArray);

        services.AddScoped<ISender, Sender>();
        return services;
    }

    private static void RegisterFor(Type openRequestInterface,
        IServiceCollection services,
        IEnumerable<Assembly> assembliesToScan)
    {
        var concretions = new List<Type>();
        var interfaces = new List<Type>();
        foreach (var type in assembliesToScan.SelectMany(a => a.DefinedTypes).Where(t => !t.IsOpenGeneric()))
        {
            var interfaceTypes = type.FindInterfacesThatClose(openRequestInterface).ToArray();
            if (!interfaceTypes.Any()) continue;

            if (type.IsConcrete()) concretions.Add(type);

            foreach (var interfaceType in interfaceTypes)
            {
                if (interfaces.Contains(interfaceType)) continue;
                interfaces.Add(interfaceType);
            }
        }

        foreach (var @interface in interfaces)
        {
            var exactMatches = concretions.Where(x => x.CanBeCastTo(@interface)).ToList();
            foreach (var type in exactMatches) services.AddTransient(@interface, type);

            if (!@interface.IsOpenGeneric()) AddConcretionsThatCouldBeClosed(@interface, concretions, services);
        }
    }

    private static void AddConcretionsThatCouldBeClosed(Type @interface, List<Type> concretions,
        IServiceCollection services)
    {
        foreach (var type in concretions
                     .Where(x => x.IsOpenGeneric() && x.CouldCloseTo(@interface)))
            try
            {
                services.TryAddTransient(@interface, type.MakeGenericType(@interface.GenericTypeArguments));
            }
            catch (Exception)
            {
            }
    }
}