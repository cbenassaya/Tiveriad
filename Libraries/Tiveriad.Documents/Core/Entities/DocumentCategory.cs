#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Documents.Core.Entities;

public class DocumentCategory : IEntity<string>
{
    [Required] public string Name { get; set; } = default!;
    [Required] public string Code { get; set; } = default!;
    [MaxLength(24)] public string Id { get; set; } = default!;
}