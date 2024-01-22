#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Applications.Commands;

public class UpdateRequestHandler<TEntity, TKey> : IRequestHandler<UpdateRequest<TEntity, TKey>, TEntity>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly IRepository<TEntity, TKey> _repository;


    public UpdateRequestHandler(IRepository<TEntity, TKey> repository)
    {
        _repository = repository;
    }

    public Task<TEntity> Handle(UpdateRequest<TEntity, TKey> request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        return Task.Run(async () =>
        {
            var entity = await _repository.GetByIdAsync(request.Entity.Id, cancellationToken);
            entity.Label = request.Entity.Label;
            entity.Code = request.Entity.Code;
            entity.Description = request.Entity.Description;
            await _repository.UpdateOneAsync(entity, cancellationToken);
            return entity;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}