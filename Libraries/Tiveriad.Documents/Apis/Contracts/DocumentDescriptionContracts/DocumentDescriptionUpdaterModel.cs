#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;

public class DocumentDescriptionUpdaterModel
{
    public string State { get; set; }
    public string Description { get; set; }
    public string? Properties { get; set; }
    [Required] public string DocumentCategoryId { get; set; } = default!;
}