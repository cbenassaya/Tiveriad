#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Documents.Core.Entities;

public class DocumentDescription : IEntity<string>, IAuditable<string>
{
    [MaxLength(100)] [Required] public string Name { get; set; } = default!;
    [Required] public DocumentState State { get; set; } = DocumentState.Published;
    public InternationalizedString? Description { get; set; }
    [MaxLength(100)] [Required] public string Path { get; set; } = default!;
    [MaxLength(20)] [Required] public string Provider { get; set; } = default!;
    public string? Reference { get; set; }
    public string? ReferenceType { get; set; }
    public Metadata? Properties { get; set; }
    public DocumentCategory? DocumentCategory { get; set; }
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    [MaxLength(24)] public string Id { get; set; } = default!;
}

public enum DocumentState
{
    Published,
    Archived
}