#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class UpdateSubjectRequestHandler : IRequestHandler<UpdateSubjectRequest, Subject>
{
    private readonly IRepository<NotificationMessage, string> _notificationMessageRepository;
    private readonly IRepository<Subject, string> _subjectRepository;
    private IRepository<Scope, string> _scopeRepository;

    public UpdateSubjectRequestHandler(IRepository<Subject, string> subjectRepository,
        IRepository<Scope, string> scopeRepository,
        IRepository<NotificationMessage, string> notificationMessageRepository)
    {
        _subjectRepository = subjectRepository;
        _scopeRepository = scopeRepository;
        _notificationMessageRepository = notificationMessageRepository;
    }


    public Task<Subject> Handle(UpdateSubjectRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _subjectRepository.Queryable.Include(x => x.Template).AsQueryable();
            query = query.Where(x => x.Id == request.Id);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.Subject.Name;
            result.Description = request.Subject.Description;
            result.State = request.Subject.State;
            if (request.Subject.Template != null)
                result.Template =
                    await _notificationMessageRepository.GetByIdAsync(request.Subject.Template.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}