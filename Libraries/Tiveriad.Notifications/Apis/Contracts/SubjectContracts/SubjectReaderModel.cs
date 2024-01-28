#region

using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Apis.Contracts.NotificationMessageContracts;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.Contracts.SubjectContracts;

public class SubjectReaderModel
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public InternationalizedString? Description { get; set; }
    public SubjectState? State { get; set; }
    public NotificationMessageReduceModel? Template { get; set; }
}