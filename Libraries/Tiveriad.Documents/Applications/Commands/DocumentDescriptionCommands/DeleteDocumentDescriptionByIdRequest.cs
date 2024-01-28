#region

using MediatR;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public record DeleteDocumentDescriptionByIdRequest(string Id) : IRequest<bool>;