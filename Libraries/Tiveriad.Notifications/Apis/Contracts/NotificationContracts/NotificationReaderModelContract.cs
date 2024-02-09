
using System;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Notifications.Apis.Contracts.SubjectContracts;
using Tiveriad.Notifications.Apis.Contracts.NotificationMessageContracts;
namespace Tiveriad.Notifications.Apis.Contracts.NotificationContracts;

public class NotificationReaderModelContract
{


    public string? Id { get; set; }
    public string? UserId { get; set; }
    public NotificationState? State { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public SubjectReduceModelContract? Subject { get; set; }
    public NotificationMessageReduceModelContract? Message { get; set; }

}

