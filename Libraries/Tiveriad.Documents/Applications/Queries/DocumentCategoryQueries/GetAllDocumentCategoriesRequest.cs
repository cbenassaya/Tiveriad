#region

using MediatR;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Queries.DocumentCategoryQueries;

public record GetAllDocumentCategoriesRequest(string? Id, int? Page, int? Limit, string? Q, IEnumerable<string>? Orders)
    : IRequest<IEnumerable<DocumentCategory>?>;