#region

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiveriad.Cqrs.Requests;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Cqrs.Commands;

public class SaveOrUpdateRequestHandler<TEntity, TKey> : IRequestHandler<SaveOrUpdateRequest<TEntity, TKey>>
    where TEntity : IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly IRepository<TEntity, TKey> _repository;

    public SaveOrUpdateRequestHandler(IRepository<TEntity, TKey> repository)
    {
        _repository = repository;
    }

    public async Task Handle(SaveOrUpdateRequest<TEntity, TKey> request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Entity.Id, cancellationToken);
        if (result == null)
            await _repository.AddOneAsync(request.Entity, cancellationToken);
        else
            await _repository.UpdateOneAsync(request.Entity, cancellationToken);
    }
}