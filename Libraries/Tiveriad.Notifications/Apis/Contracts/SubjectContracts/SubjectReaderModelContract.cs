
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Notifications.Apis.Contracts.NotificationMessageContracts;
using System.Collections.Generic;
using Tiveriad.Notifications.Apis.Contracts.ScopeContracts;
namespace Tiveriad.Notifications.Apis.Contracts.SubjectContracts;

public class SubjectReaderModelContract
{


    public string? Id { get; set; }
    public string? Name { get; set; }
    public InternationalizedString? Description { get; set; }
    public SubjectState? State { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public NotificationMessageReduceModelContract? Template { get; set; }
    public List<ScopeReduceModelContract>? Scopes { get; set; } = new();

}

