using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiveriad.Cqrs.Requests;
using Tiveriad.Repositories;

namespace Tiveriad.Cqrs.Queries;

public class GetByIdRequestHandler<TEntity, TKey> : IRequestHandler<GetByIdRequest<TEntity, TKey>, TEntity>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly IRepository<TEntity, TKey> _repository;

    public GetByIdRequestHandler(IRepository<TEntity, TKey> repository)
    {
        _repository = repository;
    }

    public Task<TEntity> Handle(GetByIdRequest<TEntity, TKey> request, CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(request.Key, cancellationToken);
    }
}