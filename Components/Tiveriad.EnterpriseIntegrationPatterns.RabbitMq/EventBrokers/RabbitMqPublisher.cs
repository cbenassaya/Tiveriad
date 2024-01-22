#region

using System.Text.Json;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Tiveriad.Commons.RetryLogic;
using Tiveriad.Connections;
using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;

public class RabbitMqPublisher<TEvent, TKey> : IPublisher<TEvent, TKey> where TEvent : IDomainEvent<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly IRabbitMqConnectionConfiguration _configuration;
    private readonly IConnectionFactory<IConnection> _connectionFactory;
    private readonly string _eventName;
    private readonly ILogger<RabbitMqPublisher<TEvent, TKey>> _logger;

    public RabbitMqPublisher(IConnectionFactory<IConnection> connectionFactory,
        IRabbitMqConnectionConfiguration configuration, string eventName,
        ILogger<RabbitMqPublisher<TEvent, TKey>> logger)
    {
        _connectionFactory = connectionFactory;
        _logger = logger;
        _eventName = eventName;
        _configuration = configuration;
    }

    public Task Publish(IDomainEvent<TKey> @event, CancellationToken cancellationToken)
    {
        var connection = _connectionFactory.GetConnection();

        connection.CallbackException += (e, context) =>
        {
            _logger.LogCritical(e.ToString());
            _logger.LogCritical(context.ToString());
        };
        var channel = connection.CreateModel();
        _logger.LogTrace("Declaring RabbitMQ exchange to publish event: {EventId}", @event.Id);
        channel.ExchangeDeclare(_configuration.BrokerName, "direct", true);
        var body = JsonSerializer.SerializeToUtf8Bytes(@event, @event.GetType(), new JsonSerializerOptions
        {
            WriteIndented = true
        });
        Retry.On<Exception>().For(3U).Execute(context =>
        {
            if (context.Exceptions.Count > 1)
                connection = _connectionFactory.GetConnection();
            var basicProperties = channel.CreateBasicProperties();
            basicProperties.DeliveryMode = 2;
            _logger.LogTrace("Publishing event to RabbitMQ: {EventId}", @event.Id);
            channel.BasicPublish(_configuration.BrokerName, _eventName, true, basicProperties,
                (ReadOnlyMemory<byte>)body);
        });
        return Task.CompletedTask;
    }
}