#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class SaveSubjectRequestHandler : IRequestHandler<SaveSubjectRequest, Subject>
{
    private readonly IRepository<Subject, string> _subjectRepository;
    private IRepository<Scope, string> _scopeRepository;

    public SaveSubjectRequestHandler(IRepository<Subject, string> subjectRepository,
        IRepository<Scope, string> scopeRepository)
    {
        _subjectRepository = subjectRepository;
        _scopeRepository = scopeRepository;
    }


    public Task<Subject> Handle(SaveSubjectRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _subjectRepository.AddOneAsync(request.Subject, cancellationToken);
            return request.Subject;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}