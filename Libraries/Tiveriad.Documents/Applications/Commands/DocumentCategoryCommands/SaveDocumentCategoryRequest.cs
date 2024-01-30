using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public record SaveDocumentCategoryRequest(string OrganizationId, DocumentCategory DocumentCategory) : IRequest<DocumentCategory>;