#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class DeleteNotificationByIdRequestHandler : IRequestHandler<DeleteNotificationByIdRequest, bool>
{
    private readonly IRepository<Notification, string> _notificationRepository;
    private IRepository<Subject, string> _subjectRepository;

    public DeleteNotificationByIdRequestHandler(IRepository<Notification, string> notificationRepository,
        IRepository<Subject, string> subjectRepository)
    {
        _notificationRepository = notificationRepository;
        _subjectRepository = subjectRepository;
    }


    public Task<bool> Handle(DeleteNotificationByIdRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _notificationRepository.Queryable.Include(x => x.Subject)
                .Include(x => x.Message).AsQueryable();
            query = query.Where(x => x.Id == request.Id);
            var notification = query.FirstOrDefault();
            if (notification == null) throw new Exception();
            return _notificationRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}