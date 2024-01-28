#region

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

#endregion

namespace Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;

public class DocumentDescriptionWriterModel
{
    [Required] [Display(Name = "File")] public IFormFile FormFile { get; set; } = default!;
    [Required] public string Name { get; set; }
    public string Description { get; set; }
    [Required] public string Path { get; set; }
    public string? Reference { get; set; }
    public string? ReferenceType { get; set; }
    public string? Properties { get; set; }
    [Required] public string DocumentCategoryId { get; set; } = default!;
}