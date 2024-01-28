#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class UpdateNotificationRequestHandler : IRequestHandler<UpdateNotificationRequest, Notification>
{
    private readonly IRepository<NotificationMessage, string> _notificationMessageRepository;
    private readonly IRepository<Notification, string> _notificationRepository;
    private readonly IRepository<Subject, string> _subjectRepository;

    public UpdateNotificationRequestHandler(IRepository<Notification, string> notificationRepository,
        IRepository<Subject, string> subjectRepository,
        IRepository<NotificationMessage, string> notificationMessageRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;
    }


    public Task<Notification> Handle(UpdateNotificationRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _notificationRepository.Queryable.Include(x => x.Subject)
                .Include(x => x.Message).AsQueryable();
            query = query.Where(x => x.Id == request.Id);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.UserId = request.Notification.UserId;
            result.State = request.Notification.State;
            if (request.Notification.Subject != null)
                result.Subject =
                    await _subjectRepository.GetByIdAsync(request.Notification.Subject.Id, cancellationToken);
            if (request.Notification.Message != null)
                result.Message =
                    await _notificationMessageRepository.GetByIdAsync(request.Notification.Message.Id,
                        cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}