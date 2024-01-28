#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.Contracts.SubjectContracts;

public class SubjectWriterModel
{
    public string? Name { get; set; }
    public InternationalizedString? Description { get; set; }
    public SubjectState? State { get; set; }
    [Required] public string TemplateId { get; set; } = default!;
    [Required] public IEnumerable<string> ScopesId { get; set; } = new List<string>();
}