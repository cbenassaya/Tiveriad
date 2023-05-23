#region

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tiveriad.Commons.Extensions;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.Mediators;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureConnectionFactory<TConnectionFactoryBuilder, TClient,
        TConnectionConfigurator, TConnectionConfiguration>(this IServiceCollection services,
        Action<TConnectionConfigurator> delegateConfigurator,
        ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        where TConnectionFactoryBuilder :
        IConnectionFactoryBuilder<TConnectionConfigurator, TConnectionConfiguration, TClient>
        where TConnectionConfigurator : class, IConnectionConfigurator
        where TConnectionConfiguration : IConnectionConfiguration
    {
        ConfigureConnectionFactoryClasses<TConnectionFactoryBuilder, TClient, TConnectionConfigurator,
            TConnectionConfiguration>(services,
            delegateConfigurator, serviceLifetime);

        return services;
    }

    private static void ConfigureConnectionFactoryClasses<TConnectionFactoryBuilder, TClient, TConnectionConfigurator,
        TConnectionConfiguration>(IServiceCollection services,
        Action<TConnectionConfigurator> delegateConfigurator,
        ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        where TConnectionFactoryBuilder :
        IConnectionFactoryBuilder<TConnectionConfigurator, TConnectionConfiguration, TClient>
        where TConnectionConfigurator : class, IConnectionConfigurator
        where TConnectionConfiguration : IConnectionConfiguration
    {
        var factoryType = typeof(TConnectionFactoryBuilder).GetTypeInfo().Assembly.DefinedTypes.FirstOrDefault(t =>
            t.IsClass
            && !t.IsAbstract
            && typeof(TConnectionFactoryBuilder).IsAssignableFrom(t.AsType()));

        if (factoryType == null)
            throw new ApplicationException($"No implementation for {typeof(TConnectionFactoryBuilder).FullName}");

        var factory = (TConnectionFactoryBuilder)Activator.CreateInstance(factoryType);
        factory.Configure(delegateConfigurator);

        services.Add(new ServiceDescriptor(typeof(TConnectionConfiguration), sp => factory.Configuration,
            ServiceLifetime.Singleton));

        var client = factory.Build();

        if (services.All(sd => sd.ServiceType != typeof(IConnectionFactory<TClient>)))
            services.Add(new ServiceDescriptor(typeof(IConnectionFactory<TClient>),
                sp => client, serviceLifetime));
    }

    public static IServiceCollection AddTiveriadEip(this IServiceCollection services,
        params Assembly[] assembliesToScan)
    {
        if (!assembliesToScan.Any())
            throw new ArgumentException(
                "No assemblies found to scan. Supply at least one assembly to scan for handlers.");

        var assembliesToScanArray = assembliesToScan ?? Array.Empty<Assembly>().ToArray();

        var openTypes = new[]
        {
            typeof(IRequest<>),
            typeof(IRequestHandler<,>),
            typeof(IEventHandler<,>)
        };

        foreach (var openInterface in openTypes)
            RegisterFor(openInterface, services, assembliesToScanArray);

        services.AddScoped<ISender, Sender>();
        services.AddScoped<IEventBroker, EventBroker>();
        services.AddScoped<IDomainEventStore, DomainEventStore>();
        services.AddScoped<IEventHandlerRunner, DefaultHandlersRunner>();
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