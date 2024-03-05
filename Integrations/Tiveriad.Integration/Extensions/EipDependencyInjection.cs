#region

using RabbitMQ.Client;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Integration.Infrastructure.Publishers;
using Tiveriad.Integration.Infrastructure.Services;
using Tiveriad.Integration.Infrastructure.Subscribers;
using Tiveriad.Integration.Infrastructure.Workers;
using Tiveriad.Registrations.Core.DomainEvents;
using Tiveriad.ServiceResolvers;
using Tiveriad.ServiceResolvers.Microsoft.DependencyInjection;

#endregion

namespace Tiveriad.Integration.Extensions;

public static class EipDependencyInjection
{
    public static IServiceCollection AddPublisher(this IServiceCollection services)
    {
        
        //services.AddSingleton<IPublisher<OnSaveRegistrationDomainEvent, string>, OnSaveRegistrationDomainEventPublisher>();
        //services.AddSingleton<ISubscriber<OnSaveRegistrationDomainEvent, string>, OnSaveRegistrationDomainEventSubscriber>();
        return services;
    }

    public static IServiceCollection AddBroker(this IServiceCollection services)
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
        services.AddSingleton<IServiceResolver, DependencyInjectionServiceResolver>();
        services.AddTiveriadEip(typeof(OnSaveUserDomainEvent).Assembly);
        services.AddScoped<IDomainEventStore, DomainEventStore>();
        return services;
    }

    public static IServiceCollection AddWorkers(this IServiceCollection services)
    {
        //services.AddHostedService<RegistrationWorker>();
        return services;
    }
}