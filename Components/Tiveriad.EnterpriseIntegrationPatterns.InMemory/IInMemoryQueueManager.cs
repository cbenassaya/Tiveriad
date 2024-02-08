using Tiveriad.Core.Abstractions.DomainEvents;

namespace Tiveriad.EnterpriseIntegrationPatterns.InMemory;

public interface IInMemoryQueueManager
{
    void AddQueue<TEvent, TKey>() where TEvent : IDomainEvent<TKey> where TKey : IEquatable<TKey>;
    void Subscribe<TEvent, TKey>(Func<TEvent, Task> subscriber) where TEvent : IDomainEvent<TKey> where TKey : IEquatable<TKey>;
    Task Publish<TEvent, TKey>(IDomainEvent<TKey> @event, CancellationToken cancellationToken) where TEvent : IDomainEvent<TKey> where TKey : IEquatable<TKey>;
}