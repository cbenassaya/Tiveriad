
using Tiveriad.Core.Abstractions.DomainEvents;
using System;
using Tiveriad.ReferenceData.Core.Entities;
namespace Tiveriad.ReferenceData.Core.DomainEvents;

[OccursOn(typeof(KeyValue))]
public class OnSaveKeyValueDomainEvent : IDomainEvent<string>
{


    public string Id { get; set; } = default!;
    public DateTimeOffset OccurredOn { get; set; } = default!;
    public KeyValue Entity { get; set; } = default!;
    public string Event { get; set; } = default!;

}

