using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Tiveriad.Core.Abstractions.DomainEvents;

namespace Tiveriad.EnterpriseIntegrationPatterns.InMemory;

public class InMemoryQueueManager : IInMemoryQueueManager
{
    private ILogger<InMemoryQueueManager> _logger;
    
    private readonly ConcurrentDictionary<Type, object> _queues = new();

    public InMemoryQueueManager(ILogger<InMemoryQueueManager> logger)
    {
        _logger = logger;
    }

    public void AddQueue<TEvent, TKey>() where TEvent : IDomainEvent<TKey> where TKey : IEquatable<TKey>
    {
        _logger.LogTrace("Adding queue for: {EventType}", typeof(TEvent).Name);
        
        _queues.TryAdd(typeof(TEvent), new InMemoryQueue<TEvent, TKey>());
    }

    public void Subscribe<TEvent, TKey>(Func<TEvent, Task> subscriber) where TEvent : IDomainEvent<TKey> where TKey : IEquatable<TKey>
    {
        _logger.LogTrace("Subscribing to: {EventType}", typeof(TEvent).Name);
        var  queue = (InMemoryQueue<TEvent, TKey>) _queues.GetOrAdd(typeof(TEvent), new InMemoryQueue<TEvent, TKey>());
        queue.AddSubscriber(subscriber);
    }

    public Task Publish<TEvent, TKey>(IDomainEvent<TKey> @event, CancellationToken cancellationToken) where TEvent : IDomainEvent<TKey> where TKey : IEquatable<TKey>
    {
        _logger.LogTrace("Publish to: {EventType}", typeof(TEvent).Name);
        var  queue = (InMemoryQueue<TEvent, TKey>) _queues.GetOrAdd(typeof(TEvent), new InMemoryQueue<TEvent, TKey>());
        queue.EnqueueTask((TEvent) @event);
        return Task.CompletedTask;
    }
}

public class InMemoryQueue<TEvent, TKey> : IDisposable where TEvent : IDomainEvent<TKey> where TKey : IEquatable<TKey>
{
    private BlockingCollection<TEvent> _queue = new (); 
    private BlockingCollection<Func<TEvent, Task>> _subscribers = new();
    
    public InMemoryQueue ()
    {
        Task.Factory.StartNew (Consume);
    }
 
    public void Dispose() { _queue.CompleteAdding(); }
 
    public void EnqueueTask (TEvent item) { _queue.Add (item); }
 
    private void Consume()
    {
        foreach (var @event in _queue.GetConsumingEnumerable())
            foreach (var subscriber in _subscribers)
                subscriber.Invoke(@event);
    }

    public void AddSubscriber(Func<TEvent, Task> subscriber) 
    {
        _subscribers.Add(subscriber);
    }
}


