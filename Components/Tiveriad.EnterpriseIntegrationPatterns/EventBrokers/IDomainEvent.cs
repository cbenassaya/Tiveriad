namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

public interface IDomainEvent<TKey> where TKey : IEquatable<TKey>
{
    DateTimeOffset OccurredOn { get; }
    TKey Id { get; }
}

/// <summary>
///     IDomainEvent is an interface that's commonly used in Domain-Driven Design (DDD) to represent an event that occurs
///     within the domain.
///     Events are used to capture and propagate changes that occur within the domain, allowing you to build a more loosely
///     coupled and scalable architecture.
///     The IDomainEvent interface defines the basic contract that a domain event should implement. The OccurredOn property
///     is used to capture the date and time when the event occurred.
///     By defining the IDomainEvent interface, you can ensure that all domain events in your system adhere to a consistent
///     contract, which can make it easier to work with and manage your events over time.
/// </summary>
/// <typeparam name="TAggregate"></typeparam>
/// <typeparam name="TKey"></typeparam>
public interface IDomainEvent<out TAggregate, TKey> : IDomainEvent<TKey>
    where TAggregate : IAggregateRoot<TKey>
    where TKey : IEquatable<TKey>
{
    TAggregate Aggregate { get; }
}