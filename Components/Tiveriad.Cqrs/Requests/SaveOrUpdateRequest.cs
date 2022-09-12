using System;
using MediatR;
using Tiveriad.Repositories;

namespace Tiveriad.Cqrs.Requests;

public record SaveOrUpdateRequest<TEntity, TKey>(TEntity Entity) : IRequest
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>;