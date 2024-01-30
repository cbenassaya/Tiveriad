using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public record SaveDocumentDescriptionRequest(string OrganizationId, DocumentDescription DocumentDescription) : IRequest<DocumentDescription>;