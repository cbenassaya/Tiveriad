
using FluentValidation;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationUpdateCommandHandlerValidator : AbstractValidator<OrganizationUpdateCommandHandlerRequest>
{
    private IRepository<Organization, string> _repository;
    public OrganizationUpdateCommandHandlerValidator(IRepository<Organization, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Organization).NotNull().WithErrorCode(ErrorCodes.OrganizationUpdateCommandHandler_Organization_XNotNullRule);
        RuleFor(x => x.Organization.Id).NotNull().WithErrorCode(ErrorCodes.Organization_Id_XNotNullRule);
        RuleFor(x => x.Organization.Name).MaximumLength(50).WithErrorCode(ErrorCodes.Organization_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Organization.Name).NotEmpty().WithErrorCode(ErrorCodes.Organization_Name_XNotEmptyRule);
        RuleFor(x => x.Organization.Logo).MaximumLength(50).WithErrorCode(ErrorCodes.Organization_Logo_XMaxLengthRule_Max_50);
        RuleFor(x => x.Organization.Domain).MaximumLength(100).WithErrorCode(ErrorCodes.Organization_Domain_XMaxLengthRule_Max_100);
        RuleFor(x => x.Organization.Description).MaximumLength(100).WithErrorCode(ErrorCodes.Organization_Description_XMaxLengthRule_Max_100);
        RuleFor(x => x.Organization.Description).NotEmpty().WithErrorCode(ErrorCodes.Organization_Description_XNotEmptyRule);
        RuleFor(x => x)
        .Must(request =>
        {
            var query = repository.Queryable;
            query = query.Where(x => x.Name == request.Organization.Name);
            return !query.ToList().Any();
        }
        ).WithErrorCode(ErrorCodes.Organization_Name_XUniqueRule);
    }


}

