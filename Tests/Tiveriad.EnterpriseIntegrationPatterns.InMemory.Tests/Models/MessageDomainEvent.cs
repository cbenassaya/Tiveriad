#region

#endregion

using Tiveriad.Core.Abstractions.DomainEvents;

namespace Tiveriad.EnterpriseIntegrationPatterns.InMemory.Tests.Models;

public class MessageDomainEvent : IDomainEvent<Guid>
{
    public string Message { get; set; }

    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public Guid Id { get; } = Guid.NewGuid();
}