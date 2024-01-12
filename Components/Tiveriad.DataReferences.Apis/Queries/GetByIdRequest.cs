#region

using MediatR;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Apis.Queries;

public record GetByIdRequest<TEntity, TKey>(TKey Id, TKey? OrganizationId) : IRequest<TEntity>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>;