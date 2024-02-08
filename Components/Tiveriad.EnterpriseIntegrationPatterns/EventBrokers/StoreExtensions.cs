using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.Core.Abstractions.Services;

namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

public static class StoreExtensions
{
    public static IEnumerable<TEvent> Entries<TEvent, TKey>(this IDomainEventStore store)
        where TEvent :IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {

        return store.GetDomainEvents()
            .Where(e => e is TEvent)
            .Cast<TEvent>();
    }
}