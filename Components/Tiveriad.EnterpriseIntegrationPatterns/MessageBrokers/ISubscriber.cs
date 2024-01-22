#region

using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.MessageBrokers;

public interface ISubscriber<TEvent, TKey>
    where TEvent : IDomainEvent<TKey>
    where TKey : IEquatable<TKey>
{
    void Subscribe();

    Task OnError(Exception exception);


}