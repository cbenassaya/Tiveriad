using System;
using MediatR;
using Tiveriad.Repositories;

namespace Tiveriad.Cqrs.Requests;

public record RemoveByIRequest<TEntity, TKey>(TKey Key) : IRequest<bool>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>;