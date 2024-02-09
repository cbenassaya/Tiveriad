
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Apis.Contracts.SubjectContracts;

public class SubjectReduceModelContract
{


    public string? Id { get; set; }
    public InternationalizedString? Description { get; set; }
    public SubjectState? State { get; set; }

}

