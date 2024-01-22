using Multitenancy.Integration.Infrastructure.Services;
using RabbitMQ.Client;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Services;
using Tiveriad.Keycloak;
using Tiveriad.Keycloak.Apis;
using Tiveriad.Keycloak.Services;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;

namespace Multitenancy.Integration.Extensions;
public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddKeycloak(this IServiceCollection services)
    {
        services.AddSingleton<KeycloakConfigurationService>();
        
        var configuration = services
            .BuildServiceProvider()
            .GetRequiredService<KeycloakConfigurationService>();
        
        UriBuilder uriBuilder = new UriBuilder
        {
            Scheme = configuration.Scheme,
            Host = configuration.Hostname,
        };
        var factory = KeycloakSessionFactory.Configurator.Get(x =>
        {
            x.SetCredential(configuration.Username, configuration.Password).SetUrlBase(uriBuilder.Uri.ToString());
        }).Build();

        services.AddSingleton(factory);
        
        services.AddSingleton( x =>
        {
            var httpClient = new HttpClient();
          
            UriBuilder uriBuilder = new UriBuilder
            {
                Scheme = configuration.Scheme,
                Host = configuration.Hostname,
                Path = configuration.Path
            };
            httpClient.BaseAddress = uriBuilder.Uri;
            return httpClient;
        });
        
        services.AddScoped<IRoleApi, RoleApi>();
        services.AddScoped<IUserApi, UserApi>();
        services.AddScoped<IRoleMapperApi, RoleMapperApi>();
        services.AddScoped<IIdentityService, KeycloakIdentityService>();
        
        return services;
    }


    public static IServiceCollection AddRabbitMq(this IServiceCollection services)
    {
        services.AddSingleton<RabbitMqConfigurationService>();
        var configuration = services
            .BuildServiceProvider()
            .GetRequiredService<RabbitMqConfigurationService>();
        
        services.ConfigureConnectionFactory<RabbitMqConnectionFactoryBuilder, IConnection, RabbitMqConnectionConfigurator,
            IRabbitMqConnectionConfiguration>
        ( configurator =>
            {
                configurator
                    .SetHost(configuration.Hostname)
                    .SetUsername(configuration.Username)
                    .SetPassword(configuration.Password)
                    .SetBrokerName(configuration.Exchange);
            }
        );
        services.AddScoped<IServiceResolver, DependencyInjectionServiceResolver>();
        services.AddTiveriadEip(typeof(UserDomainEvent).Assembly);
        services.AddScoped<IDomainEventStore, DomainEventStore>();
        return services;
    }


}