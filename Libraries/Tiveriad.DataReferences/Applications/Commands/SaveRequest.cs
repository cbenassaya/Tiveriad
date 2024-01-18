#region

using MediatR;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Apis.Commands;

public record SaveRequest<TEntity, TKey>(TEntity Entity) : IRequest<TEntity>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>;