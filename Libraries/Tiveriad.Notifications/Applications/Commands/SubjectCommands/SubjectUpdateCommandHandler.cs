
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class SubjectUpdateCommandHandler : IRequestHandler<SubjectUpdateCommandHandlerRequest, Subject>
{
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    private IRepository<Scope, string> _scopeRepository;
    public SubjectUpdateCommandHandler(IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository, IRepository<Scope, string> scopeRepository)
    {
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;
        _scopeRepository = scopeRepository;

    }


    public Task<Subject> Handle(SubjectUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            var query = _subjectRepository.Queryable.Include(x => x.Template).AsQueryable();



            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.Subject.Name;
            result.Description = request.Subject.Description;
            result.State = request.Subject.State;
            if (request.Subject.Template != null) result.Template = await _notificationMessageRepository.GetByIdAsync(request.Subject.Template.Id, cancellationToken);
            return result;
        }, cancellationToken);
        
    }
}

