#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Applications.Commands;

public class SaveRequestHandler<TEntity, TKey> : IRequestHandler<SaveRequest<TEntity, TKey>, TEntity>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly IRepository<TEntity, TKey> _repository;


    public SaveRequestHandler(IRepository<TEntity, TKey> repository)
    {
        _repository = repository;
    }

    public Task<TEntity> Handle(SaveRequest<TEntity, TKey> request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        return Task.Run(async () =>
        {
            await _repository.AddOneAsync(request.Entity, cancellationToken);
            return request.Entity;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}