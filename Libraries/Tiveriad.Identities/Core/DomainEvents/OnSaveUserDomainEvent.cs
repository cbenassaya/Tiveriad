
using Tiveriad.Core.Abstractions.DomainEvents;
using System;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Core.DomainEvents;

[OccursOn(typeof(User))]
public class OnSaveUserDomainEvent : IDomainEvent<string>
{


    public string Id { get; set; } = default!;
    public DateTimeOffset OccurredOn { get; set; } = default!;
    public User Entity { get; set; } = default!;
    public string Event { get; set; } = default!;

}

