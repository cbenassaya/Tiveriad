using MediatR;

namespace Tiveriad.Documents.Applications.Queries.DocumentCategoryQueries;

public record GetDocumentCategoryByIdRequest(string OrganizationId, string Id) : IRequest<DocumentCategory?>;