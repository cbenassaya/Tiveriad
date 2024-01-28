using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;
using Tiveriad.Identities.Core.DomainEvents;

namespace Tiveriad.Integration.Infrastructure.Publishers;

public class OrganizationDomainEventPublisher: RabbitMqPublisher<OrganizationDomainEvent, string>
{
    public OrganizationDomainEventPublisher(
        IConnectionFactory<IConnection> connectionFactory,
        IRabbitMqConnectionConfiguration configuration,
        string eventName,
        ILogger<OrganizationDomainEventPublisher> logger) : base(connectionFactory, configuration, eventName, logger)
    {
    }
}