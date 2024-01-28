#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.SubjectQueries;

public class GetAllSubjectsPreValidator : AbstractValidator<GetAllSubjectsRequest>
{
    private IRepository<Subject, string> _repository;

    public GetAllSubjectsPreValidator(IRepository<Subject, string> repository)
    {
        _repository = repository;
    }
}