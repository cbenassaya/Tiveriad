
using FluentValidation;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationCommands;

public class RegistrationSaveCommandHandlerValidator : AbstractValidator<RegistrationSaveCommandHandlerRequest>
{
    private IRepository<Registration, string> _repository;
    public RegistrationSaveCommandHandlerValidator(IRepository<Registration, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Registration).NotNull().WithErrorCode(ErrorCodes.RegistrationSaveCommandHandler_Registration_XNotNullRule);
        RuleFor(x => x.Registration.Description).MaximumLength(500).WithErrorCode(ErrorCodes.Registration_Description_XMaxLengthRule_Max_500);
        RuleFor(x => x.Registration.Description).NotEmpty().WithErrorCode(ErrorCodes.Registration_Description_XNotEmptyRule);
        RuleFor(x => x.Registration.OrganizationName).MaximumLength(50).WithErrorCode(ErrorCodes.Registration_OrganizationName_XMaxLengthRule_Max_50);
        RuleFor(x => x.Registration.OrganizationName).NotEmpty().WithErrorCode(ErrorCodes.Registration_OrganizationName_XNotEmptyRule);
        RuleFor(x => x.Registration.Firstname).MaximumLength(100).WithErrorCode(ErrorCodes.Registration_Firstname_XMaxLengthRule_Max_100);
        RuleFor(x => x.Registration.Firstname).NotEmpty().WithErrorCode(ErrorCodes.Registration_Firstname_XNotEmptyRule);
        RuleFor(x => x.Registration.Lastname).MaximumLength(100).WithErrorCode(ErrorCodes.Registration_Lastname_XMaxLengthRule_Max_100);
        RuleFor(x => x.Registration.Lastname).NotEmpty().WithErrorCode(ErrorCodes.Registration_Lastname_XNotEmptyRule);
        RuleFor(x => x.Registration.Username).MaximumLength(100).WithErrorCode(ErrorCodes.Registration_Username_XMaxLengthRule_Max_100);
        RuleFor(x => x.Registration.Username).NotEmpty().WithErrorCode(ErrorCodes.Registration_Username_XNotEmptyRule);
        RuleFor(x => x.Registration.Password).MaximumLength(12).WithErrorCode(ErrorCodes.Registration_Password_XMaxLengthRule_Max_12);
        RuleFor(x => x.Registration.Password).MinimumLength(12).WithErrorCode(ErrorCodes.Registration_Password_XMinLengthRule_Min_12);
        RuleFor(x => x.Registration.Password).NotEmpty().WithErrorCode(ErrorCodes.Registration_Password_XNotEmptyRule);
        RuleFor(x => x.Registration.Email).MaximumLength(100).WithErrorCode(ErrorCodes.Registration_Email_XMaxLengthRule_Max_100);
        RuleFor(x => x.Registration.Email).NotEmpty().WithErrorCode(ErrorCodes.Registration_Email_XNotEmptyRule);
        RuleFor(x => x.Registration.DefaultLocale).MaximumLength(12).WithErrorCode(ErrorCodes.Registration_DefaultLocale_XMaxLengthRule_Max_12);
        RuleFor(x => x.Registration.DefaultLocale).NotEmpty().WithErrorCode(ErrorCodes.Registration_DefaultLocale_XNotEmptyRule);
        RuleFor(x => x)
        .Must(request =>
        {
            var query = repository.Queryable;
            query = query.Where(x => x.OrganizationName == request.Registration.OrganizationName);
            return !query.ToList().Any();
        }
        ).WithErrorCode(ErrorCodes.Registration_OrganizationName_XUniqueRule);
    }


}

