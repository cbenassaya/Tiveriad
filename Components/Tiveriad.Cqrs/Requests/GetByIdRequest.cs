using System;
using MediatR;
using Tiveriad.Repositories;

namespace Tiveriad.Cqrs.Requests;

public record GetByIdRequest<TEntity, TKey>(TKey Key) : IRequest<TEntity>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>;