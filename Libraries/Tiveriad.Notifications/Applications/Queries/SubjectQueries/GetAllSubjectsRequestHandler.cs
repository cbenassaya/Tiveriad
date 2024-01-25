#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public class GetAllSubjectsRequestHandler : IRequestHandler<GetAllSubjectsRequest, IEnumerable<Subject>>
{
    private readonly IRepository<Subject, string> _subjectRepository;

    public GetAllSubjectsRequestHandler(IRepository<Subject, string> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public Task<IEnumerable<Subject>> Handle(GetAllSubjectsRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _subjectRepository.Queryable;
        if (!string.IsNullOrEmpty(request.Id))
            query = query.Where(x => x.Id == request.Id);
        if (!string.IsNullOrEmpty(request.Name))
            query = query.Where(x => x.Name.Contains(request.Name));
        if (!string.IsNullOrEmpty(request.Q))
            query = query.Where(x =>
                x.Name.Contains(request.Q));
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                if (order.StartsWith("-"))
                    query = query.OrderByDescending(x => EF.Property<object>(x, order.Substring(1)));
                else
                    query = query.OrderBy(x => EF.Property<object>(x, order));
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}