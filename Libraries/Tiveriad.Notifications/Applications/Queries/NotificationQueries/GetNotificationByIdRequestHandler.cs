#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.NotificationQueries;

public class GetNotificationByIdRequestHandler : IRequestHandler<GetNotificationByIdRequest, Notification?>
{
    private readonly IRepository<Notification, string> _notificationRepository;
    private IRepository<Subject, string> _subjectRepository;

    public GetNotificationByIdRequestHandler(IRepository<Notification, string> notificationRepository,
        IRepository<Subject, string> subjectRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
    }


    public Task<Notification?> Handle(GetNotificationByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _notificationRepository.Queryable.Include(x => x.Subject)
            .Include(x => x.Message).AsQueryable();
        query = query.Where(x => x.Id == request.Id);
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}