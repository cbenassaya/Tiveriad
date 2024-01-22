using Tiveriad.Core.Abstractions.Entities;

namespace Tiveriad.Notifications.Core;

public class Topic:IEntity<string>,IAuditable<string>
{
    public string Id { get; set; }
    public string Subject { get; set; }
    public NotificationMessage Template { get; set; }
    public InternationalizedString Name { get; set; }
    public InternationalizedString Description { get; set; }
    public string CreatedBy { get; set; }
    public DateTime Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
}