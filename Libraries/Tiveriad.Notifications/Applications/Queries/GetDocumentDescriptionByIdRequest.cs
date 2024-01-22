#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Queries;

public record GetDocumentDescriptionByIdRequest<T>(
    T? Id
)
    : IRequest<DocumentDescriptionBase<T>>
    where T : IEquatable<T>;