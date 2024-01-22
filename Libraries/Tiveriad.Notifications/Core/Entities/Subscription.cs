using Tiveriad.Core.Abstractions.Entities;

namespace Tiveriad.Notifications.Core;

public class Subscription : IEntity<string>, IAuditable<string>
{
    public string Id { get; set; }
    public Topic Topic { get; set; }
    public string OrganizationId { get; set; }
    public string ApplicationId { get; set; }
    public string RoleId { get; set; }
    public string GroupId { get; set; }
    public string UserId { get; set; }
    public string SubjectId { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}