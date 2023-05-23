#region

using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.Tests.Models;

public class MessageDomainEventSubscriber : RabbitMqSubscriber<MessageDomainEvent, Guid>
{
    public MessageDomainEventSubscriber(
        IConnectionFactory<IConnection> connectionFactory,
        IRabbitMqConnectionConfiguration configuration,
        string queueName,
        string eventName,
        ILogger<MessageDomainEventSubscriber> logger) : base(connectionFactory, configuration, queueName, eventName,
        logger)
    {
    }

    public int Count { get; private set; }

    public override async Task OnError(Exception exception)
    {
        //Do Nothing
    }

    public override async Task Handle(MessageDomainEvent @event)
    {
        Count++;
    }
}