#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Documents.Apis.Contracts.DocumentCategoryContracts;

public class DocumentCategoryReduceModel
{
    [MaxLength(24)] public string? Id { get; set; }
    public string? Name { get; set; }
}