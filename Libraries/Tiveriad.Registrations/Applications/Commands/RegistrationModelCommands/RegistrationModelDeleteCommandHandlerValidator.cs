
using FluentValidation;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Registrations.Core.Entities;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationModelCommands;

public class RegistrationModelDeleteCommandHandlerValidator : AbstractValidator<RegistrationModelDeleteCommandHandlerRequest>
{
    private IRepository<RegistrationModel, string> _repository;
    public RegistrationModelDeleteCommandHandlerValidator(IRepository<RegistrationModel, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.RegistrationModelDeleteCommandHandler_Id_XNotNullRule);
    }


}

