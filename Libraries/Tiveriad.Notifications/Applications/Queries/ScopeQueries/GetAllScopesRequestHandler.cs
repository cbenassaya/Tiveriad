#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.ScopeQueries;

public class GetAllScopesRequestHandler : IRequestHandler<GetAllScopesRequest, IEnumerable<Scope>>
{
    private readonly IRepository<Scope, string> _scopeRepository;

    public GetAllScopesRequestHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;
    }


    public Task<IEnumerable<Scope>> Handle(GetAllScopesRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _scopeRepository.Queryable;
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}