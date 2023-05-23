#region

using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Tiveriad.Commons.RetryLogic;
using Tiveriad.Connections;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.EventBrokers;

public abstract class RabbitMqSubscriber<TEvent, TKey> : ISubscriber<TEvent, TKey>
    where TEvent : IDomainEvent<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly IRabbitMqConnectionConfiguration _configuration;
    private readonly IConnectionFactory<IConnection> _connectionFactory;
    private readonly string _eventName;
    private readonly ILogger<RabbitMqSubscriber<TEvent, TKey>> _logger;
    private readonly string _queueName;
    private IModel _consumerChannel;

    public RabbitMqSubscriber(IConnectionFactory<IConnection> connectionFactory,
        IRabbitMqConnectionConfiguration configuration, string queueName, string eventName,
        ILogger<RabbitMqSubscriber<TEvent, TKey>> logger)
    {
        _connectionFactory = connectionFactory;
        _logger = logger;
        _configuration = configuration;
        _queueName = queueName;
        _eventName = eventName;
    }

    public void Subscribe()
    {
        Retry.On<Exception>().For(3).Execute(context =>
        {
            if (context.Exceptions.Count > 0)
                Task.Delay(TimeSpan.FromMilliseconds(500));

            _logger.LogInformation("Subscribing to dynamic event ${Event}", _eventName);
            var connection = _connectionFactory.GetConnection();
            _consumerChannel = connection.CreateModel();

            _consumerChannel.CallbackException += (sender, e) =>
            {
                _logger.LogWarning(e.Exception, "Recreating RabbitMQ consumer channel");
            };

            _logger.LogTrace("Creating RabbitMQ consumer channel");
            _consumerChannel.ExchangeDeclare(_configuration.BrokerName, ExchangeType.Direct, true);

            _consumerChannel.QueueDeclare(_queueName,
                true,
                false,
                false,
                null);

            _consumerChannel.QueueBind(_queueName,
                _configuration.BrokerName,
                _eventName);

            _logger.LogTrace("Starting RabbitMQ basic consume");
            var consumer = new EventingBasicConsumer(_consumerChannel);
            consumer.Received += OnConsumerReceived;

            _consumerChannel.BasicConsume(
                _queueName,
                false,
                consumer);
        });
    }

    public abstract Task OnError(Exception exception);

    public abstract Task Handle(TEvent @event);

    private void OnConsumerReceived(object sender, BasicDeliverEventArgs eventArgs)
    {
        var message = Encoding.UTF8.GetString(eventArgs.Body.Span);
        try
        {
            if (message.ToLowerInvariant().Contains("throw-fake-exception"))
                throw new InvalidOperationException($"Fake exception requested: \"{message}\"");

            try
            {
                var @event = JsonSerializer.Deserialize<TEvent>(message);
                Handle(@event);
            }
            catch (Exception e)
            {
                OnError(e);
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "----- ERROR Processing message \"{Message}\"", message);
        }

        // Even on exception we take the message off the queue.
        // in a REAL WORLD app this should be handled with a Dead Letter Exchange (DLX). 
        // For more information see: https://www.rabbitmq.com/dlx.html
        _consumerChannel.BasicAck(eventArgs.DeliveryTag, false);
    }
}