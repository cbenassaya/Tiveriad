#region

using MediatR;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Apis.Queries;

public record GetAllRequest<TEntity, TKey>
(
    TKey? Id,
    TKey? OrganizationId,
    string? Name,
    string? Code,
    string? Locale,
    int? Page, int? Limit,
    string? Q, string[]? Orders
) : IRequest<IEnumerable<TEntity>>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>;