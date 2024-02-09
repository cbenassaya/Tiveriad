
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class SubjectDeleteCommandHandler : IRequestHandler<SubjectDeleteCommandHandlerRequest, bool>
{
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    private IRepository<Scope, string> _scopeRepository;
    public SubjectDeleteCommandHandler(IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository, IRepository<Scope, string> scopeRepository)
    {
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;
        _scopeRepository = scopeRepository;

    }


    public Task<bool> Handle(SubjectDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    //<-- START CUSTOM CODE-->
    var query = _subjectRepository.Queryable.Include(x => x.Template).AsQueryable();
    query = query.Where(x => x.Id == request.Id);


    var subject = query.FirstOrDefault();
    if (subject == null) throw new Exception();
    return _subjectRepository.DeleteMany(x => x.Id == request.Id) == 1;
}, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

