#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.TimeAreaQueries;

public class TimeAreaGetAllQueryHandler : IRequestHandler<TimeAreaGetAllQueryHandlerRequest, List<TimeArea>>
{
    private readonly IRepository<TimeArea, string> _timeAreaRepository;

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
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}