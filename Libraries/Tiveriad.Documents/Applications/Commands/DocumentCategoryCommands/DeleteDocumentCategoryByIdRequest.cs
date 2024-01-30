using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public record DeleteDocumentCategoryByIdRequest(string OrganizationId, string Id) : IRequest<bool>;