using Microsoft.Extensions.Logging;
using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.EnterpriseIntegrationPatterns.Mediators;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;

namespace Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;

public class InMemoryPublisher<TEvent, TKey> : IPublisher<TEvent, TKey> where TEvent : IDomainEvent<TKey>
    where TKey : IEquatable<TKey>
{
    
    private readonly IInMemoryQueueManager _queueManager;
    private readonly ILogger<InMemoryPublisher<TEvent, TKey>> _logger;
    
    private ISender _sender;

    public InMemoryPublisher(IInMemoryQueueManager queueManager, ILogger<InMemoryPublisher<TEvent, TKey>> logger)
    {
        _queueManager = queueManager;
        _logger = logger;
    }

    public Task Publish(IDomainEvent<TKey> @event, CancellationToken cancellationToken = default)
    {
        _logger.LogTrace("Publishing event to InMemory: {EventId}", @event.Id);
        return _queueManager.Publish<TEvent,TKey>(@event,cancellationToken);
    }
}