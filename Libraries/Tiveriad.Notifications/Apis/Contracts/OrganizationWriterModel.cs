#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Notifications.Apis.Contracts;

public class SubjectWriterModel
{
    [Required] public string Name { get; set; } = string.Empty;

    [MaxLength(500)] public string? Description { get; set; } = string.Empty;

}