
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Queries.ScopeQueries;

public class ScopeGetAllQueryHandler : IRequestHandler<ScopeGetAllQueryHandlerRequest, List<Scope>>
{
    private IRepository<Scope, string> _scopeRepository;
    public ScopeGetAllQueryHandler(IRepository<Scope, string> scopeRepository)
    {
        _scopeRepository = scopeRepository;

    }


    public Task<List<Scope>> Handle(ScopeGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        
        var query = _scopeRepository.Queryable;
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ?
                query.OrderByDescending(order.Substring(1)) :
                query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        
    }
}

