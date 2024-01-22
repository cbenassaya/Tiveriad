#region

using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq.Tests.Models;

public class MessageDomainEvent : IDomainEvent<Guid>
{
    public string Message { get; set; }

    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public Guid Id { get; } = Guid.NewGuid();
}