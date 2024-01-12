#region

using MediatR;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Apis.Queries;

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
        if (!default(TKey)!.Equals(request.OrganizationId))
            query = query.Where(x =>
                (x.OrganizationId.Equals(request.OrganizationId) && x.Visibility == Visibility.Private) ||
                x.Visibility == Visibility.Public);
        if (!default(TKey)!.Equals(request.Id))
            query = query.Where(x => x.Id.Equals(request.Id));
        if (request.Name != null)
            query = query.Where(x => x.Label.Contains(request.Name));
        if (request.Code != null)
            query = query.Where(x => x.Code == request.Code);
        if (request.Q != null)
            query = query.Where(x => x.Label.Contains(request.Q) || x.Description.Contains(request.Q));
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-")
                    ? query.OrderByDescending(x => typeof(TEntity).GetProperty(order.Substring(1)))
                    : query.OrderBy(x => typeof(TEntity).GetProperty(order));
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
    }
}