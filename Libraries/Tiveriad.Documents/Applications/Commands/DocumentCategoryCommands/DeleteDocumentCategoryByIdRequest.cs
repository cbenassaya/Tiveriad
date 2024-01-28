#region

using MediatR;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public record DeleteDocumentCategoryByIdRequest(string Id) : IRequest<bool>;