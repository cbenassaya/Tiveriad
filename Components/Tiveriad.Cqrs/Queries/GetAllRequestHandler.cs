#region

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Cqrs.Requests;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Cqrs.Queries;

public class
    GetAllRequestHandler<TEntity, TKey> : IRequestHandler<GetAllRequest<TEntity, TKey>, IEnumerable<TEntity>>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly IRepository<TEntity, TKey> _repository;

    public GetAllRequestHandler(IRepository<TEntity, TKey> repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<TEntity>> Handle(GetAllRequest<TEntity, TKey> request,
        CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(cancellationToken);
    }
}