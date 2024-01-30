using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public record DeleteDocumentDescriptionByIdRequest(string OrganizationId, string Id) : IRequest<bool>;