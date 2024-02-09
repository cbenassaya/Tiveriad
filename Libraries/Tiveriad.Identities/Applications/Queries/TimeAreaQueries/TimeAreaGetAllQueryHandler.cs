
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.TimeAreaQueries;

public class TimeAreaGetAllQueryHandler : IRequestHandler<TimeAreaGetAllQueryHandlerRequest, List<TimeArea>>
{
    private IRepository<TimeArea, string> _timeAreaRepository;
    public TimeAreaGetAllQueryHandler(IRepository<TimeArea, string> timeAreaRepository)
    {
        _timeAreaRepository = timeAreaRepository;

    }


    public Task<List<TimeArea>> Handle(TimeAreaGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _timeAreaRepository.Queryable;
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ?
                query.OrderByDescending(order.Substring(1)) :
                query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

