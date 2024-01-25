#region

using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Notifications.Core.Entities;

public class Subject : IEntity<string>, IAuditable<string>
{
    public string Name { get; set; }
    public SubjectState State { get; set; }
    public NotificationMessage Template { get; set; } = null!;
    public List<Scope> Scopes { get; } = new();
    public InternationalizedString? Description { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string Id { get; set; }
}

public enum SubjectState
{
    Pending,
    Activated,
    Canceled
}