#region

using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Documents.Apis.Contracts.DocumentCategoryContracts;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;

public class DocumentDescriptionReaderModel
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public DocumentState? State { get; set; }
    public string Description { get; set; }
    public string? Path { get; set; }
    public string? Provider { get; set; }
    public string? Reference { get; set; }
    public string? ReferenceType { get; set; }
    public Metadata? Properties { get; set; }
    public DocumentCategoryReduceModel? DocumentCategory { get; set; }
}