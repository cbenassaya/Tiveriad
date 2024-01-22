#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Commands;

public record SaveDocumentDescriptionRequest<T>(DocumentDescriptionBase<T> DocumentDescriptionBase)
    : IRequest<DocumentDescriptionBase<T>>
    where T : IEquatable<T>;