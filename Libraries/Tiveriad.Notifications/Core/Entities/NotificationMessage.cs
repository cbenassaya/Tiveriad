#region

using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Notifications.Core.Entities;

public class NotificationMessage : IEntity<string>
{
    public InternationalizedString Subject { get; set; } = null!;

    public InternationalizedString? Body { get; set; }

    public InternationalizedString? ConfirmLink { get; set; }

    public InternationalizedString? ConfirmText { get; set; }

    public InternationalizedString? ImageSmall { get; set; }

    public InternationalizedString? ImageLarge { get; set; }

    public InternationalizedString? LinkUrl { get; set; }

    public InternationalizedString? LinkText { get; set; }

    public ConfirmMode? ConfirmMode { get; set; }
    public string Id { get; set; } = null!;
}