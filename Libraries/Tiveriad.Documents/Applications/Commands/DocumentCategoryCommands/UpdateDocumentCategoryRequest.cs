using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public record UpdateDocumentCategoryRequest(string OrganizationId, string Id, DocumentCategory DocumentCategory) : IRequest<DocumentCategory>;