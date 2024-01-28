#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class DeleteSubjectByIdRequestHandler : IRequestHandler<DeleteSubjectByIdRequest, bool>
{
    private readonly IRepository<Subject, string> _subjectRepository;
    private IRepository<Scope, string> _scopeRepository;

    public DeleteSubjectByIdRequestHandler(IRepository<Subject, string> subjectRepository,
        IRepository<Scope, string> scopeRepository)
    {
        _subjectRepository = subjectRepository;
        _scopeRepository = scopeRepository;
    }


    public Task<bool> Handle(DeleteSubjectByIdRequest request, CancellationToken cancellationToken)
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