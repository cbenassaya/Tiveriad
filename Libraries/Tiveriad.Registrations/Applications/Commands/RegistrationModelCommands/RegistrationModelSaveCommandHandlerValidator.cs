
using FluentValidation;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationModelCommands;

public class RegistrationModelSaveCommandHandlerValidator : AbstractValidator<RegistrationModelSaveCommandHandlerRequest>
{
    private IRepository<RegistrationModel, string> _repository;
    public RegistrationModelSaveCommandHandlerValidator(IRepository<RegistrationModel, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.RegistrationModel).NotNull().WithErrorCode(ErrorCodes.RegistrationModelSaveCommandHandler_RegistrationModel_XNotNullRule);
        RuleFor(x => x.RegistrationModel.Name).MaximumLength(50).WithErrorCode(ErrorCodes.RegistrationModel_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.RegistrationModel.Name).NotEmpty().WithErrorCode(ErrorCodes.RegistrationModel_Name_XNotEmptyRule);
        RuleFor(x => x.RegistrationModel.Description).MaximumLength(500).WithErrorCode(ErrorCodes.RegistrationModel_Description_XMaxLengthRule_Max_500);
        RuleFor(x => x.RegistrationModel.Description).NotEmpty().WithErrorCode(ErrorCodes.RegistrationModel_Description_XNotEmptyRule);
    }


}

