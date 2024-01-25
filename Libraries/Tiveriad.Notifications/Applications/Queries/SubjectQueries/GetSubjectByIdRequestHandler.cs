#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public class GetSubjectByIdRequestHandler : IRequestHandler<GetSubjectByIdRequest, Subject?>
{
    private readonly IRepository<Subject, string>? _subjectRepository;

    public GetSubjectByIdRequestHandler(IRepository<Subject, string> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public Task<Subject?> Handle(GetSubjectByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _subjectRepository.Queryable.Where(x => x.Id == request.Id);
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}