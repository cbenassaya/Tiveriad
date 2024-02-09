#region

using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory;
using Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;
using Tiveriad.Registrations.Core.DomainEvents;

#endregion

namespace Tiveriad.Integration.Infrastructure.Publishers;

public class OnSaveRegistrationDomainEventPublisher : RabbitMqPublisher<OnSaveRegistrationDomainEvent, string>
{
    public OnSaveRegistrationDomainEventPublisher(
        IConnectionFactory<IConnection> connectionFactory,
        IRabbitMqConnectionConfiguration configuration,
        ILogger<OnSaveRegistrationDomainEventPublisher> logger) : base(connectionFactory, configuration, typeof(OnSaveRegistrationDomainEvent).Name, logger)
    {
    }
}