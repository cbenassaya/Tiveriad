#region

using Tiveriad.Core.Abstractions.DomainEvents;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Core.DomainEvents;

public class UserDomainEvent : IDomainEvent<string>
{
    public User User { get; set; }
    public string EventType { get; set; }
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.Now;
    public string Id { get; } = Guid.NewGuid().ToString();
}