#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Applications.Queries;

public class
    GetAllRequestHandler<TEntity, TKey> : IRequestHandler<GetAllRequest<TEntity, TKey>, IEnumerable<TEntity>>
    where TEntity : IDataReference<TKey>, new()
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
        var query = _repository.Queryable;
        if (!request.OrganizationId.Equals(default))
            query = query.Where(x =>
                (x.OrganizationId.Equals(request.OrganizationId) && x.Visibility == Visibility.Private) ||
                x.Visibility == Visibility.Public);
        if (request.Id != null && !request.Id.Equals(default))
            query = query.Where(x => x.Id.Equals(request.Id));
        if (request.Code != null)
            query = query.Where(x => x.Code == request.Code);
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-")
                    ? query.OrderByDescending(order.Substring(1))
                    : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
    }
}