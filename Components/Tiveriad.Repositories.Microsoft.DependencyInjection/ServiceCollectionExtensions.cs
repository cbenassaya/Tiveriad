using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tiveriad.Commons.Extensions;
using Tiveriad.Connections;

namespace Tiveriad.Repositories.Microsoft.DependencyInjection;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection ConfigureConnectionFactory<TConnectionFactoryBuilder, TClient,
        TConnectionConfigurator,TConnectionConfiguration>(this IServiceCollection services,
        Action<TConnectionConfigurator> delegateConfigurator,
        ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        where TConnectionFactoryBuilder : IConnectionFactoryBuilder<TConnectionConfigurator, TConnectionConfiguration, TClient>
        where TConnectionConfigurator : class, IConnectionConfigurator
        where TConnectionConfiguration:IConnectionConfiguration
    {
         ConfigureConnectionFactoryClasses<TConnectionFactoryBuilder, TClient, TConnectionConfigurator, TConnectionConfiguration>(services,
            delegateConfigurator, serviceLifetime);
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, Type repositoryType,
        params Assembly[] assemblies)
    {
         AddRepositoryClasses(services, repositoryType, assemblies, new []{typeof(IEntity<>)});
         return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, Type repositoryType,
        IEnumerable<Assembly> assemblies, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
    {
         AddRepositoryClasses(services, repositoryType, assemblies, new []{typeof(IEntity<>)}, serviceLifetime);
        
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, Type repositoryType,
        params Type[] profileAssemblyMarkerTypes)
    {
         AddRepositoryClasses(services, repositoryType,
            profileAssemblyMarkerTypes.Select(t => t.GetTypeInfo().Assembly), new []{typeof(IEntity<>)});

         return services;
    }
    
    private static void ConfigureConnectionFactoryClasses<TConnectionFactoryBuilder, TClient, TConnectionConfigurator, TConnectionConfiguration>(IServiceCollection services,
        Action<TConnectionConfigurator> delegateConfigurator, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        where TConnectionFactoryBuilder : IConnectionFactoryBuilder< TConnectionConfigurator, TConnectionConfiguration,TClient> 
        where TConnectionConfigurator : class, IConnectionConfigurator
        where TConnectionConfiguration:IConnectionConfiguration
    {
        var factoryType = typeof(TConnectionFactoryBuilder).GetTypeInfo().Assembly.DefinedTypes.FirstOrDefault(t => t.IsClass
            && !t.IsAbstract
            && typeof(TConnectionFactoryBuilder).IsAssignableFrom(t.AsType()));

        if (factoryType == null)
            throw new ApplicationException($"No implementation for {typeof(TConnectionFactoryBuilder).FullName}");

        var factory = (TConnectionFactoryBuilder)Activator.CreateInstance(factoryType);
        factory.Configure(delegateConfigurator);

        services.Add(new ServiceDescriptor(typeof(TConnectionConfiguration), sp => delegateConfigurator,
            ServiceLifetime.Singleton));
        var client = factory.Build();

        if (services.All(sd => sd.ServiceType != typeof(IConnectionFactory<TClient>)))
            services.Add(new ServiceDescriptor(typeof( IConnectionFactory<TClient>),
                sp => client, serviceLifetime));

    }
    
    
    private static Type? FindKeyType(TypeInfo typeInfo, Type[] openTypes)
    {
        var implementedInterface =
            typeInfo.ImplementedInterfaces?.FirstOrDefault(x => openTypes.Any(y => y.Name.Equals(x.Name)));
        if (implementedInterface != null)
            return implementedInterface.GetGenericArguments().First();
        return typeInfo.BaseType != null ? FindKeyType(typeInfo.BaseType.GetTypeInfo(), openTypes) : null;
    }
    
    
    private static void AddRepositoryClasses(IServiceCollection services, Type repositoryType,
        IEnumerable<Assembly> assembliesToScan, Type[] openTypes,
        ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
    {

        var assembliesToScanArray = assembliesToScan as Assembly[] ?? assembliesToScan?.ToArray();
        if (assembliesToScanArray != null && assembliesToScanArray.Length > 0)
        {
            var allTypes = assembliesToScanArray
                .Where(a => !a.IsDynamic)
                .Distinct()
                .SelectMany(a => a.DefinedTypes)
                .ToArray();

            foreach (var type in openTypes.SelectMany(openType => allTypes
                         .Where(t => t.IsClass
                                     && !t.IsAbstract
                                     && t.AsType().ImplementsGenericInterface(openType))))
            {
                var keyType = FindKeyType(type, openTypes);
                if (keyType == null) continue;
                var iRepositoryType = typeof(IRepository<,>);
                var iGenericRepositoryType = iRepositoryType.MakeGenericType( new[] { type.AsType(), keyType });
                var genericRepositoryBaseType =  repositoryType.GetGenericArguments().Length==1 ? repositoryType.MakeGenericType( new[] { type.AsType() }) :  repositoryType.MakeGenericType( new[] { type.AsType(), keyType });
                // use try add to avoid double-registration
                services.TryAddTransient(iGenericRepositoryType, genericRepositoryBaseType);
            }
        }
    }
}