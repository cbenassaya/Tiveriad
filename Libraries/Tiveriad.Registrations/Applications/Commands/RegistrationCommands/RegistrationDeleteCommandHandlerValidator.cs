
using FluentValidation;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Registrations.Core.Entities;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationCommands;

public class RegistrationDeleteCommandHandlerValidator : AbstractValidator<RegistrationDeleteCommandHandlerRequest>
{
    private IRepository<Registration, string> _repository;
    public RegistrationDeleteCommandHandlerValidator(IRepository<Registration, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.RegistrationDeleteCommandHandler_Id_XNotNullRule);
    }


}

