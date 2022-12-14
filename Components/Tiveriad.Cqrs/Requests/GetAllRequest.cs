using System;
using System.Collections.Generic;
using MediatR;
using Tiveriad.Repositories;

namespace Tiveriad.Cqrs.Requests;

public record GetAllRequest<TEntity, TKey> : IRequest<IEnumerable<TEntity>>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>;