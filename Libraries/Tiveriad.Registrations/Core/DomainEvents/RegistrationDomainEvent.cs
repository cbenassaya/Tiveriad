#region

using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.Registrations.Core.Entities;

#endregion

namespace Tiveriad.Registrations.Core.DomainEvents;

public class RegistrationDomainEvent : IDomainEvent<string>
{
    public Registration Registration { get; set; } = default!;
    public string EventType { get; set; } = default!;
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public string Id { get; } = Guid.NewGuid().ToString();
}