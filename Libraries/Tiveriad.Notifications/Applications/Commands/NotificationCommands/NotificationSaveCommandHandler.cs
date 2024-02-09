
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class NotificationSaveCommandHandler : IRequestHandler<NotificationSaveCommandHandlerRequest, Notification>
{
    private IRepository<Notification, string> _notificationRepository;
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    public NotificationSaveCommandHandler(IRepository<Notification, string> notificationRepository, IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;

    }


    public Task<Notification> Handle(NotificationSaveCommandHandlerRequest request, CancellationToken cancellationToken)
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

