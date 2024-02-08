using Microsoft.Extensions.Logging;
using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;

namespace Tiveriad.EnterpriseIntegrationPatterns.InMemory.EventBrokers;

public abstract class InMemorySubscriber<TEvent, TKey> : ISubscriber<TEvent, TKey>
    where TEvent : IDomainEvent<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly IInMemoryQueueManager _queueManager;
    private ILogger<InMemorySubscriber<TEvent, TKey>> _logger;

    protected InMemorySubscriber(IInMemoryQueueManager queueManager, ILogger<InMemorySubscriber<TEvent, TKey>> logger)
    {
        _queueManager = queueManager;
        _logger = logger;
    }


    public void Subscribe()
    {
        _logger.LogTrace("Subscribing to InMemory: {EventType}", typeof(TEvent).Name);
        _queueManager.Subscribe<TEvent,TKey>(Handle);
    }

    public abstract Task OnError(Exception exception);

    public Task Handle(TEvent @event)
    {
        try
        {
            _logger.LogTrace("Handling event: {EventId}", @event.Id);
            return DoHandle(@event);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error handling event: {EventId}", @event.Id);
            return OnError(e);
        }
    }
    
    
    public abstract Task DoHandle(TEvent @event);
}