#region

using System;
using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Cqrs.Requests;

public record RemoveByIRequest<TEntity, TKey>(TKey Key) : IRequest<bool>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>;