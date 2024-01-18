using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Core.DomainEvents;

public class UserDomainEvent:IDomainEvent<string>
{
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public string Id { get; } = Guid.NewGuid().ToString();
    public User User { get; set; }
    public string EventType  { get; set; }
}