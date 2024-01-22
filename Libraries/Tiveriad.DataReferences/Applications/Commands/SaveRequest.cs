#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.DataReferences.Applications.Commands;

public record SaveRequest<TEntity, TKey>(TEntity Entity) : IRequest<TEntity>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>;