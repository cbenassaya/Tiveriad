#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.SubjectQueries;

public class GetAllSubjectsRequestHandler : IRequestHandler<GetAllSubjectsRequest, IEnumerable<Subject>>
{
    private readonly IRepository<Subject, string> _subjectRepository;
    private IRepository<Scope, string> _scopeRepository;

    public GetAllSubjectsRequestHandler(IRepository<Subject, string> subjectRepository,
        IRepository<Scope, string> scopeRepository)
    {
        _subjectRepository = subjectRepository;
        _scopeRepository = scopeRepository;
    }


    public Task<IEnumerable<Subject>> Handle(GetAllSubjectsRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _subjectRepository.Queryable.Include(x => x.Template).AsQueryable();
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