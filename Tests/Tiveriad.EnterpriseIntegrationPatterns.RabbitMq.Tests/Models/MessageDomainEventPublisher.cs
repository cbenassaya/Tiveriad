#region

using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.Tests.Models;

public class MessageDomainEventPublisher : RabbitMqPublisher<MessageDomainEvent, Guid>
{
    public MessageDomainEventPublisher(
        IConnectionFactory<IConnection> connectionFactory,
        IRabbitMqConnectionConfiguration configuration,
        string eventName,
        ILogger<MessageDomainEventPublisher> logger) : base(connectionFactory, configuration, eventName, logger)
    {
    }
}