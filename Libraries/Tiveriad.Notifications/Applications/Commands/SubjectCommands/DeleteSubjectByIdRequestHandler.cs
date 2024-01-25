#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class DeleteSubjectByIdRequestHandler : IRequestHandler<DeleteSubjectByIdRequest, bool>
{
    private readonly IRepository<Subject, string> _subjectRepository;

    public DeleteSubjectByIdRequestHandler(IRepository<Subject, string> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public Task<bool> Handle(DeleteSubjectByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() =>
        {
            var subject = _subjectRepository.GetById(request.Id);
            var result = _subjectRepository.DeleteOne(subject) == 1;
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}