#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.Contracts.SubjectContracts;

public class SubjectReduceModel
{
    [MaxLength(24)] public string? Id { get; set; }
    [MaxLength(100)] [Required] public InternationalizedString Description { get; set; } = null;
    [Required] public SubjectState State { get; set; } = default!;
}