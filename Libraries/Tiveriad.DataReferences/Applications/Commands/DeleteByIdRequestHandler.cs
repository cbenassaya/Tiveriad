#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Applications.Commands;

public class DeleteByIdRequestHandler<TEntity, TKey> : IRequestHandler<DeleteByIdRequest<TEntity, TKey>, long>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly IRepository<TEntity, TKey> _repository;


    public DeleteByIdRequestHandler(IRepository<TEntity, TKey> repository)
    {
        _repository = repository;
    }

    public Task<long> Handle(DeleteByIdRequest<TEntity, TKey> request, CancellationToken cancellationToken)
    {
        

        var query = _repository.Queryable.Where(x =>
            x.Id.Equals(request.Id) && x.OrganizationId.Equals(request.OrganizationId));

        return Task.Run(async () =>
        {
            var entity = query.FirstOrDefault();
            if (entity == null)
                throw new Exception($"{typeof(TEntity).Name}_NOT_FOUND");
            return await _repository.DeleteOneAsync(entity, cancellationToken);
        }, cancellationToken);
        
    }
}