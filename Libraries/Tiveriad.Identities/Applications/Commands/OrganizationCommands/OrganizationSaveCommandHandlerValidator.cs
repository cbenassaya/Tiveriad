#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationSaveCommandHandlerValidator : AbstractValidator<OrganizationSaveCommandHandlerRequest>
{
    private IRepository<Organization, string> _repository;

    public OrganizationSaveCommandHandlerValidator(IRepository<Organization, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Organization).NotNull()
            .WithErrorCode(ErrorCodes.OrganizationSaveCommandHandler_Organization_XNotNullRule);
        RuleFor(x => x.Organization.Name).MaximumLength(50)
            .WithErrorCode(ErrorCodes.Organization_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Organization.Name).NotEmpty().WithErrorCode(ErrorCodes.Organization_Name_XNotEmptyRule);
        RuleFor(x => x.Organization.Logo).MaximumLength(50)
            .WithErrorCode(ErrorCodes.Organization_Logo_XMaxLengthRule_Max_50);
        RuleFor(x => x.Organization.Domain).MaximumLength(100)
            .WithErrorCode(ErrorCodes.Organization_Domain_XMaxLengthRule_Max_100);
        RuleFor(x => x.Organization.Domain).NotEmpty().WithErrorCode(ErrorCodes.Organization_Domain_XNotEmptyRule);
        RuleFor(x => x.Organization.Description).MaximumLength(100)
            .WithErrorCode(ErrorCodes.Organization_Description_XMaxLengthRule_Max_100);
        RuleFor(x => x.Organization.Description).NotEmpty()
            .WithErrorCode(ErrorCodes.Organization_Description_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Name == request.Organization.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Organization_Name_XUniqueRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Domain == request.Organization.Domain);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Organization_Domain_XUniqueRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Name == request.Organization.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Organization_XBusinessKeyRule);
    }
}