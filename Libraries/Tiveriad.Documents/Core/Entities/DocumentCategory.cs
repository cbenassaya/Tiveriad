
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace Tiveriad.Documents.Core.Entities;

public class DocumentCategory : IEntity<string>, IAuditable<string>, IWithTenant<string>
{
    [MaxLength(24)] public string Id { get; set; } = default!;
    [Required] public string Name { get; set; } = default!;
    [Required] public string Code { get; set; } = default!;
    [Required] public string CreatedBy { get; set; } = default!;
    [Required] public DateTime Created { get; set; } = default!;
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }
    [Required] public string OrganizationId { get; set; } = default!;
    public Visibility Visibility { get; set; }
}

