
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Queries.NotificationQueries;

public class NotificationGetByIdQueryHandler : IRequestHandler<NotificationGetByIdQueryHandlerRequest, Notification?>
{
    private IRepository<Notification, string> _notificationRepository;
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    public NotificationGetByIdQueryHandler(IRepository<Notification, string> notificationRepository, IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;

    }


    public Task<Notification?> Handle(NotificationGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _notificationRepository.Queryable.Include(x => x.Subject)
        .Include(x => x.Message).AsQueryable();
        query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

