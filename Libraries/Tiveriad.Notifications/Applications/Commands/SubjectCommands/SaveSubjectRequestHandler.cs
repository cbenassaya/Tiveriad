#region

using MediatR;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class SaveSubjectRequestHandler : IRequestHandler<SaveSubjectRequest, Subject>
{
    private readonly IDomainEventStore _store;
    private readonly IRepository<Subject, string> _subjectRepository;

    public SaveSubjectRequestHandler(IRepository<Subject, string> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public Task<Subject> Handle(SaveSubjectRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            _subjectRepository.AddOneAsync(request.Subject, cancellationToken);

            return request.Subject;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}