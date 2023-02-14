using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

namespace Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;

public interface IPublisher<TEvent,TKey>
    where TEvent:IDomainEvent < TKey> 
    where TKey : IEquatable<TKey>
{
    Task Publish(IDomainEvent<TKey> @event, CancellationToken cancellationToken = default);
}