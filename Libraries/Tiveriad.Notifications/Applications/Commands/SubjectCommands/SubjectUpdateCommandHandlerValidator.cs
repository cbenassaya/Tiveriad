
using FluentValidation;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class SubjectUpdateCommandHandlerValidator : AbstractValidator<SubjectUpdateCommandHandlerRequest>
{
    private IRepository<Subject, string> _repository;
    public SubjectUpdateCommandHandlerValidator(IRepository<Subject, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Subject).NotNull().WithErrorCode(ErrorCodes.SubjectUpdateCommandHandler_Subject_XNotNullRule);
        RuleFor(x => x.Subject.Id).NotNull().WithErrorCode(ErrorCodes.Subject_Id_XNotNullRule);
        RuleFor(x => x.Subject.Name).NotEmpty().WithErrorCode(ErrorCodes.Subject_Name_XNotEmptyRule);
        RuleFor(x => x.Subject.Name).MaximumLength(100).WithErrorCode(ErrorCodes.Subject_Name_XMaxLengthRule_Max_100);
        RuleFor(x => x.Subject.Description).NotNull().WithErrorCode(ErrorCodes.Subject_Description_XNotNullRule);
    }


}

