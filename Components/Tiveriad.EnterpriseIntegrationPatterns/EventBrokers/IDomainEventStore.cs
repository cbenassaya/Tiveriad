using System.Collections.Concurrent;

namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

public interface IDomainEventStore
{
    void Add<TEvent, TKey>(TEvent @event)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>;

    void Commit();
    void Rollback();
    IReadOnlyCollection<object> GetDomainEvents();

}