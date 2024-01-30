using MediatR;

namespace Tiveriad.Documents.Applications.Queries.DocumentDescriptionQueries;

public record GetDocumentDescriptionByIdRequest(string OrganizationId, string Id) : IRequest<DocumentDescription?>;