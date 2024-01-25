#region

using FluentValidation;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public class GetSubjectByIdPreValidator : AbstractValidator<GetSubjectByIdRequest>
{
    private IRepository<Subject, string> _subjectRepository;

    public GetSubjectByIdPreValidator(IRepository<Subject, string> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }
}