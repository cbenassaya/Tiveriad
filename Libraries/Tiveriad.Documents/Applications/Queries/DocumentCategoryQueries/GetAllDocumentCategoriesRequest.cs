using MediatR;

namespace Tiveriad.Documents.Applications.Queries.DocumentCategoryQueries;

public record GetAllDocumentCategoriesRequest(string OrganizationId, string? Id, int? Page, int? Limit, string? Q, IEnumerable<string>? Orders) : IRequest<IEnumerable<DocumentCategory>?>;