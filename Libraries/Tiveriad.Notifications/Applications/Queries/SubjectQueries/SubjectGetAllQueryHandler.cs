
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public class SubjectGetAllQueryHandler : IRequestHandler<SubjectGetAllQueryHandlerRequest, List<Subject>>
{
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    private IRepository<Scope, string> _scopeRepository;
    public SubjectGetAllQueryHandler(IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository, IRepository<Scope, string> scopeRepository)
    {
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;
        _scopeRepository = scopeRepository;

    }


    public Task<List<Subject>> Handle(SubjectGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _subjectRepository.Queryable.Include(x => x.Template).AsQueryable();
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

