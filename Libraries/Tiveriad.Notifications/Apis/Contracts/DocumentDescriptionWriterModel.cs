#region

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

#endregion

namespace Tiveriad.Documents.Apis.Contracts;

public class DocumentDescriptionWriterModel
{
    [Required] [Display(Name = "File")] public IFormFile FormFile { get; set; }

    public string Path { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
    public string ReferenceType { get; set; }
    public Dictionary<string, object> Properties { get; set; }
}