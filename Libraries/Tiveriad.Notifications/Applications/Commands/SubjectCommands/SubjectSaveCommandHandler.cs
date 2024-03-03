
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class SubjectSaveCommandHandler : IRequestHandler<SubjectSaveCommandHandlerRequest, Subject>
{
    private IRepository<Subject, string> _subjectRepository;
    private IRepository<NotificationMessage, string> _notificationMessageRepository;
    private IRepository<Scope, string> _scopeRepository;
    public SubjectSaveCommandHandler(IRepository<Subject, string> subjectRepository, IRepository<NotificationMessage, string> notificationMessageRepository, IRepository<Scope, string> scopeRepository)
    {
        _subjectRepository = subjectRepository;
        _notificationMessageRepository = notificationMessageRepository;
        _scopeRepository = scopeRepository;

    }


    public Task<Subject> Handle(SubjectSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            await _subjectRepository.AddOneAsync(request.Subject, cancellationToken);
            return request.Subject;
        }, cancellationToken);
        
    }
}

