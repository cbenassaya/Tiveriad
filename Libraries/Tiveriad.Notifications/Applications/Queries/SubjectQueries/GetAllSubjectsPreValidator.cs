#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public class GetAllSubjectsPreValidator : AbstractValidator<GetAllSubjectsRequest>
{
    private IRepository<Subject, string> _subjectRepository;

    public GetAllSubjectsPreValidator(IRepository<Subject, string> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }
}