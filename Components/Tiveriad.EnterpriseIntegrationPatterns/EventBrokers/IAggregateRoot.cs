namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

public interface IAggregateRoot
{
}

/// <summary>
///     IAggregateRoot is an interface that's commonly used in Domain-Driven Design (DDD) to represent the root entity of
///     an aggregate.
///     An aggregate is a cluster of domain objects that are bound together by a root entity and treated as a single unit
///     with regard to data changes.
///     The IAggregateRoot interface defines the basic contract that a root entity should implement.
///     The Id property is used to identify the aggregate root, and it's usually a Guid to ensure that each instance of an
///     aggregate root has a unique identifier.
/// </summary>
/// <typeparam name="TKey"></typeparam>
public interface IAggregateRoot<TKey> : IAggregateRoot
    where TKey : IEquatable<TKey>
{
    TKey Id { get; }
    IReadOnlyCollection<IDomainEvent<IAggregateRoot<TKey>, TKey>> DomainEvents { get; set; }
    void Add(IDomainEvent<IAggregateRoot<TKey>, TKey> domainEvents);
}