
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class NotificationUpdateCommandHandler : IRequestHandler<NotificationUpdateCommandHandlerRequest, Notification>
{
    private IRepository<Notification, string> _notificationRepository;
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    public NotificationUpdateCommandHandler(IRepository<Notification, string> notificationRepository, IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;

    }


    public Task<Notification> Handle(NotificationUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _notificationRepository.Queryable.Include(x => x.Subject)
    .Include(x => x.Message).AsQueryable();



            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.UserId = request.Notification.UserId;
            result.State = request.Notification.State;
            if (request.Notification.Subject != null) result.Subject = await _subjectRepository.GetByIdAsync(request.Notification.Subject.Id, cancellationToken);
            if (request.Notification.Message != null) result.Message = await _notificationMessageRepository.GetByIdAsync(request.Notification.Message.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

