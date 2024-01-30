using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public record UpdateDocumentDescriptionRequest(string OrganizationId, string Id, DocumentDescription DocumentDescription) : IRequest<DocumentDescription>;