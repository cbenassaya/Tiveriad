using Tiveriad.Core.Abstractions.Entities;

namespace Tiveriad.Notifications.Core;

public class NotificationMessage:IEntity<string>
{
    public string Id { get; set; }

    public InternationalizedString Subject { get; set; }

    public InternationalizedString? Body { get; set; }

    public InternationalizedString? ConfirmLink { get; set; }

    public InternationalizedString? ConfirmText { get; set; }

    public InternationalizedString? ImageSmall { get; set; }

    public InternationalizedString? ImageLarge { get; set; }

    public InternationalizedString? LinkUrl { get; set; }

    public InternationalizedString? LinkText { get; set; }

    public ConfirmMode? ConfirmMode { get; set; }
}