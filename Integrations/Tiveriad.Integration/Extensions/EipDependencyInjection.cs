using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Services;
using Tiveriad.Integration.Infrastructure.Publishers;
using Tiveriad.Integration.Infrastructure.Services;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;

namespace Tiveriad.Integration.Extensions;

public static class EipDependencyInjection
{
    

    public static IServiceCollection AddPublisher(this IServiceCollection services)
    {
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        services.AddSingleton<IPublisher<UserDomainEvent, string>>(sp => new UserDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(UserDomainEvent).FullName,
            sp.GetRequiredService<ILogger<UserDomainEventPublisher>>()));
        services.AddSingleton<IPublisher<OrganizationDomainEvent, string>>(sp => new OrganizationDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(OrganizationDomainEvent).FullName,
            sp.GetRequiredService<ILogger<OrganizationDomainEventPublisher>>()));
        services.AddSingleton<IPublisher<MembershipDomainEvent, string>>(sp => new MembershipDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(MembershipDomainEvent).FullName,
            sp.GetRequiredService<ILogger<MembershipDomainEventPublisher>>()));
        
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