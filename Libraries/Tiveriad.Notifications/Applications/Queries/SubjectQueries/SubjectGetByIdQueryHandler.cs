
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public class SubjectGetByIdQueryHandler : IRequestHandler<SubjectGetByIdQueryHandlerRequest, Subject?>
{
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    private IRepository<Scope, string> _scopeRepository;
    public SubjectGetByIdQueryHandler(IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository, IRepository<Scope, string> scopeRepository)
    {
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;
        _scopeRepository = scopeRepository;

    }


    public Task<Subject?> Handle(SubjectGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _subjectRepository.Queryable.Include(x => x.Template).AsQueryable();
        query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

