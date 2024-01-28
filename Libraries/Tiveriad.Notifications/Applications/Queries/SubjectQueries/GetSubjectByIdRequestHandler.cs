#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.SubjectQueries;

public class GetSubjectByIdRequestHandler : IRequestHandler<GetSubjectByIdRequest, Subject?>
{
    private readonly IRepository<Subject, string> _subjectRepository;
    private IRepository<Scope, string> _scopeRepository;

    public GetSubjectByIdRequestHandler(IRepository<Subject, string> subjectRepository,
        IRepository<Scope, string> scopeRepository)
    {
        _subjectRepository = subjectRepository;
        _scopeRepository = scopeRepository;
    }


    public Task<Subject?> Handle(GetSubjectByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _subjectRepository.Queryable.Include(x => x.Template).AsQueryable();
        query = query.Where(x => x.Id == request.Id);
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}