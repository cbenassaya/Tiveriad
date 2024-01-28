#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.SubjectQueries;

public class GetSubjectByIdPreValidator : AbstractValidator<GetSubjectByIdRequest>
{
    private IRepository<Subject, string> _repository;

    public GetSubjectByIdPreValidator(IRepository<Subject, string> repository)
    {
        _repository = repository;
    }
}