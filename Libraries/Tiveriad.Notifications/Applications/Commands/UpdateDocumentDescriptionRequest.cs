#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Commands;

public record UpdateDocumentDescriptionRequest<T>(DocumentDescriptionBase<T> DocumentDescriptionBase)
    : IRequest<DocumentDescriptionBase<T>>
    where T : IEquatable<T>;