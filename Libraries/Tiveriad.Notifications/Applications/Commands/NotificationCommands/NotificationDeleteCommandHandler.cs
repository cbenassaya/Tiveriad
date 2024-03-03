
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class NotificationDeleteCommandHandler : IRequestHandler<NotificationDeleteCommandHandlerRequest, bool>
{
    private IRepository<Notification, string> _notificationRepository;
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    public NotificationDeleteCommandHandler(IRepository<Notification, string> notificationRepository, IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;

    }


    public Task<bool> Handle(NotificationDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    
    var query = _notificationRepository.Queryable.Include(x => x.Subject)
    .Include(x => x.Message).AsQueryable();
    query = query.Where(x => x.Id == request.Id);


    var notification = query.FirstOrDefault();
    if (notification == null) throw new Exception();
    return _notificationRepository.DeleteMany(x => x.Id == request.Id) == 1;
}, cancellationToken);
        
    }
}

