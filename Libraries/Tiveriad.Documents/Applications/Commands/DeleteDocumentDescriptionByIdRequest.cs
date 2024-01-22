#region

using MediatR;

#endregion

namespace Tiveriad.Documents.Applications.Commands;

public record DeleteDocumentDescriptionByIdRequest<T>(T Id) : IRequest<bool>
    where T : IEquatable<T>;