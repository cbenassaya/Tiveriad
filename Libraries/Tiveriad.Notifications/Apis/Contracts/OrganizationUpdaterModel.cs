#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Notifications.Apis.Contracts;

public class SubjectUpdaterModel
{
    [Required] public string Id { get; set; } =null!;
    [Required] public string Name { get; set; } =null!;

    [MaxLength(500)] public string? Description { get; set; }
}