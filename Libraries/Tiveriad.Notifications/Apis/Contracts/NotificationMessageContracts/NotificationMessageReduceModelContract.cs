
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Apis.Contracts.NotificationMessageContracts;

public class NotificationMessageReduceModelContract
{


    public string? Id { get; set; }
    public InternationalizedString? Title { get; set; }
    public InternationalizedString? Body { get; set; }
    public InternationalizedString? ConfirmLink { get; set; }
    public InternationalizedString? ConfirmText { get; set; }
    public InternationalizedString? ImageSmall { get; set; }
    public InternationalizedString? ImageLarge { get; set; }
    public InternationalizedString? LinkUrl { get; set; }
    public InternationalizedString? LinkText { get; set; }
    public ConfirmMode? ConfirmMode { get; set; }

}

