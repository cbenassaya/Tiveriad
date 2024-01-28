#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class SaveNotificationRequestHandler : IRequestHandler<SaveNotificationRequest, Notification>
{
    private readonly IRepository<Notification, string> _notificationRepository;
    private IRepository<Subject, string> _subjectRepository;

    public SaveNotificationRequestHandler(IRepository<Notification, string> notificationRepository,
        IRepository<Subject, string> subjectRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
    }


    public Task<Notification> Handle(SaveNotificationRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _notificationRepository.AddOneAsync(request.Notification, cancellationToken);
            return request.Notification;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}