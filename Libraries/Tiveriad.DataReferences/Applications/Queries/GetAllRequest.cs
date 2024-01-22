#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.DataReferences.Applications.Queries;

public record GetAllRequest<TEntity, TKey>(
    TKey? Id,
    TKey OrganizationId,
    string? Code,
    int? Page,
    int? Limit,
    string? Q,
    string[]? Orders
) : IRequest<IEnumerable<TEntity>>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>;