using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.DependencyInjection;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.Tests.Models;
using Tiveriad.EnterpriseIntegrationPatterns.ServiceResolvers;
using Tiveriad.UnitTests;

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.Tests.EventBrokers;

public class EventBrokerStartup : StartupBase
{
    //docker run -d --hostname my-rabbit --name some-rabbit -e RABBITMQ_DEFAULT_USER=user -e RABBITMQ_DEFAULT_PASS=password rabbitmq:3-management
    public override void Configure(IServiceCollection services)
    {
        services.AddLogging(config  =>
        {
        });
        services.AddScoped<IServiceResolver, DependencyInjectionServiceResolver>();
        services.AddTiveriadEip(GetType().Assembly);

        services.ConfigureConnectionFactory<RabbitMqConnectionFactoryBuilder, IConnection, RabbitMqConnectionConfigurator,
                IRabbitMqConnectionConfiguration>
            (configurator =>
                {
                    configurator
                        .SetHost("localhost")
                        .SetUsername("guest")
                        .SetPassword("guest")
                        .SetBrokerName("TEST");
                }
            );
        services.AddSingleton<ISubscriber<MessageDomainEvent, Guid>>(sp =>
        {
            var subscriber = new MessageDomainEventSubscriber(
                sp.GetRequiredService<IConnectionFactory<IConnection>>(),
                sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
                "TEST_QUEUE",
                typeof(MessageDomainEvent).FullName,
                sp.GetRequiredService<ILogger<MessageDomainEventSubscriber>>());
            subscriber.Subscribe();
            return subscriber;
        });
        
        services.AddScoped<IPublisher<MessageDomainEvent, Guid>>(sp => new MessageDomainEventPublisher(
            sp.GetRequiredService<IConnectionFactory<IConnection>>(),
            sp.GetRequiredService<IRabbitMqConnectionConfiguration>(),
            typeof(MessageDomainEvent).FullName,
            sp.GetRequiredService<ILogger<MessageDomainEventPublisher>>()));
    }
    
}

