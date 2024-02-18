#region

using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Core.DomainEvents;

[OccursOn(typeof(Membership))]
public class OnUpdateMembershipDomainEvent : IDomainEvent<string>
{
    public Membership Entity { get; set; } = default!;
    public string Event { get; set; } = default!;


    public string Id { get; set; } = default!;
    public DateTimeOffset OccurredOn { get; set; } = default!;
}