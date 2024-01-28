#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.NotificationQueries;

public class GetAllNotificationsRequestHandler : IRequestHandler<GetAllNotificationsRequest, IEnumerable<Notification>>
{
    private readonly IRepository<Notification, string> _notificationRepository;
    private IRepository<Subject, string> _subjectRepository;

    public GetAllNotificationsRequestHandler(IRepository<Notification, string> notificationRepository,
        IRepository<Subject, string> subjectRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
    }


    public Task<IEnumerable<Notification>> Handle(GetAllNotificationsRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _notificationRepository.Queryable.Include(x => x.Subject)
            .Include(x => x.Message).AsQueryable();
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