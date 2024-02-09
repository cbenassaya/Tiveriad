
using Tiveriad.Core.Abstractions.DomainEvents;
using System;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Core.DomainEvents;

[OccursOn(typeof(Membership))]
public class OnDeleteMembershipDomainEvent : IDomainEvent<string>
{


    public string Id { get; set; } = default!;
    public DateTimeOffset OccurredOn { get; set; } = default!;
    public Membership Entity { get; set; } = default!;
    public string Event { get; set; } = default!;

}

