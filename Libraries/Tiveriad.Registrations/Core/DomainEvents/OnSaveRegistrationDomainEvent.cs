
using Tiveriad.Core.Abstractions.DomainEvents;
using System;
using Tiveriad.Registrations.Core.Entities;
namespace Tiveriad.Registrations.Core.DomainEvents;

[OccursOn(typeof(Registration))]
public class OnSaveRegistrationDomainEvent : IDomainEvent<string>
{


    public string Id { get; set; } = default!;
    public DateTimeOffset OccurredOn { get; set; } = default!;
    public Registration Entity { get; set; } = default!;
    public string Event { get; set; } = default!;

}

