
using FluentValidation;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public class SubjectGetByIdQueryHandlerValidator : AbstractValidator<SubjectGetByIdQueryHandlerRequest>
{
    private IRepository<Subject, string> _repository;
    public SubjectGetByIdQueryHandlerValidator(IRepository<Subject, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.SubjectGetByIdQueryHandler_Id_XNotNullRule);
    }


}

