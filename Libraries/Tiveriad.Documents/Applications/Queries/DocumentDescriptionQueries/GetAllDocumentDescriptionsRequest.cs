using MediatR;

namespace Tiveriad.Documents.Applications.Queries.DocumentDescriptionQueries;

public record GetAllDocumentDescriptionsRequest(string OrganizationId, string? Id, int? Page, int? Limit, string? Q, IEnumerable<string>? Orders) : IRequest<IEnumerable<DocumentDescription>?>;