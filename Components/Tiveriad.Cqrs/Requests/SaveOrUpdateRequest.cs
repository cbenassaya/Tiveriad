#region

using System;
using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Cqrs.Requests;

public record SaveOrUpdateRequest<TEntity, TKey>(TEntity Entity) : IRequest
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>;