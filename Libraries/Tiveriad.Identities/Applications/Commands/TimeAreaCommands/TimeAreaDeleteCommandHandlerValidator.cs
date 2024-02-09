
using FluentValidation;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public class TimeAreaDeleteCommandHandlerValidator : AbstractValidator<TimeAreaDeleteCommandHandlerRequest>
{
    private IRepository<TimeArea, string> _repository;
    public TimeAreaDeleteCommandHandlerValidator(IRepository<TimeArea, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.TimeAreaDeleteCommandHandler_Id_XNotNullRule);
    }


}

