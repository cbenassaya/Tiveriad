
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Queries.NotificationQueries;

public class NotificationGetAllQueryHandler : IRequestHandler<NotificationGetAllQueryHandlerRequest, List<Notification>>
{
    private IRepository<Notification, string> _notificationRepository;
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    public NotificationGetAllQueryHandler(IRepository<Notification, string> notificationRepository, IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;

    }


    public Task<List<Notification>> Handle(NotificationGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        
        var query = _notificationRepository.Queryable.Include(x => x.Subject)
        .Include(x => x.Message).AsQueryable();
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

