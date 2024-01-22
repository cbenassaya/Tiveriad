#region

using System;
using System.Collections.Generic;
using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Cqrs.Requests;

public record GetAllRequest<TEntity, TKey> : IRequest<IEnumerable<TEntity>>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>;