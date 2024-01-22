#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Queries;

public record GetAllDocumentDescriptionRequest<T>(
    T? Id = default,
    string? Name = default, 
    string? Reference = default,
    string? ReferenceType = default,
    int? Page = null,
    int? Limit = null,
    string? Q = null,
    string[]? Orders = null
)
    : IRequest<IEnumerable<DocumentDescriptionBase<T>>>
    where T : IEquatable<T>;