#region

using MediatR;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class UpdateSubjectRequestHandler : IRequestHandler<UpdateSubjectRequest, Subject>
{
    private readonly IDomainEventStore _store;
    private readonly IRepository<Subject, string> _subjectRepository;

    public UpdateSubjectRequestHandler(IRepository<Subject, string> subjectRepository,
        IDomainEventStore store)
    {
        _subjectRepository = subjectRepository;
        _store = store;
    }

    public Task<Subject> Handle(UpdateSubjectRequest request, CancellationToken cancellationToken)
    {
        var query = _subjectRepository.Queryable.Where(x => x.Id == request.Subject.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new IdentitiesException(IdentitiesError.BAD_REQUEST);

            result.Name = request.Subject.Name;
            result.Description = request.Subject.Description;
            _store.Add<SubjectDomainEvent, string>(new SubjectDomainEvent
                { Subject = result, EventType = "UPDATE" });
            return result;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}