#region

using System;
using MediatR;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Cqrs.Requests;

public record GetByIdRequest<TEntity, TKey>(TKey Key) : IRequest<TEntity>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>;