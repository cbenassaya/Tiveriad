
using FluentValidation;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public class SubjectDeleteCommandHandlerValidator : AbstractValidator<SubjectDeleteCommandHandlerRequest>
{
    private IRepository<Subject, string> _repository;
    public SubjectDeleteCommandHandlerValidator(IRepository<Subject, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.SubjectDeleteCommandHandler_Id_XNotNullRule);
    }


}

