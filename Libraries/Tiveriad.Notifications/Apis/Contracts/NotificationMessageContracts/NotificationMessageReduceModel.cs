#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Notifications.Apis.Contracts.NotificationMessageContracts;

public class NotificationMessageReduceModel
{
    [MaxLength(24)] public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? ConfirmLink { get; set; }
    public string? ConfirmText { get; set; }
    public string? ImageSmall { get; set; }
    public string? ImageLarge { get; set; }
    public string? LinkUrl { get; set; }
    public string? LinkText { get; set; }
    public string? ConfirmMode { get; set; }
}