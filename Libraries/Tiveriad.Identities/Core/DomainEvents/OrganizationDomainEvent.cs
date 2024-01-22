#region

using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Core.DomainEvents;

public class OrganizationDomainEvent : IDomainEvent<string>
{
    public Organization Organization { get; set; }
    public string EventType { get; set; }
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public string Id { get; } = Guid.NewGuid().ToString();
}

public class ClientDomainEvent : IDomainEvent<string>
{
    public Client Client { get; set; }
    public string EventType { get; set; }
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public string Id { get; } = Guid.NewGuid().ToString();
}