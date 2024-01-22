#region

using MediatR;
using Microsoft.Extensions.Logging;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Applications.Queries;

public class GetByIdRequestHandler<TEntity, TKey> : IRequestHandler<GetByIdRequest<TEntity, TKey>, TEntity>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly ILogger<GetByIdRequestHandler<TEntity, TKey>> _logger;
    private readonly IRepository<TEntity, TKey> _repository;

    public GetByIdRequestHandler(IRepository<TEntity, TKey> repository,
        ILogger<GetByIdRequestHandler<TEntity, TKey>> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public Task<TEntity> Handle(GetByIdRequest<TEntity, TKey> request, CancellationToken cancellationToken)
    {
        var query = _repository.Queryable;
        query = query.Where(x => x.Id.Equals(request.Id));
        if (request.OrganizationId != null)
            query = query.Where(x =>
                (x.OrganizationId.Equals(request.OrganizationId) && x.Visibility == Visibility.Private) ||
                x.Visibility == Visibility.Public);


        return Task.Run(() =>
        {
            var result = query.FirstOrDefault();
            if (result == null) _logger.LogError($"{typeof(TEntity).Name}_NOT_FOUND");
            return result;
        }, cancellationToken);
    }
}