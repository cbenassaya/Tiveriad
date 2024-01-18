using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Core.DomainEvents;

public class RoleDomainEvent:IDomainEvent<string>
{
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public string Id { get; } = Guid.NewGuid().ToString();
    public Role Role { get; set; }
    public string EventType  { get; set; }
}