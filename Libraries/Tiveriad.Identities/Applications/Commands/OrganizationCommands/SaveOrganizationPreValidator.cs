#region

using System.Data;
using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class SaveOrganizationPreValidator : AbstractValidator<SaveOrganizationRequest>
{
    public SaveOrganizationPreValidator(
        IRepository<Organization, string> organizationRepository)
    {
        RuleFor(x => x.Organization.Name).NotEmpty().WithMessage("Name is required").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_NAME_REQUIRED");
        RuleFor(x=>x.Owner).NotNull().WithMessage("Owner is required").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_REQUIRED");
        RuleFor(x=>x.Owner.Firstname).NotEmpty().WithMessage("Owner first name is required").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_FIRSTNAME_REQUIRED");
        RuleFor(x=>x.Owner.Lastname).NotEmpty().WithMessage("Owner last name is required").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_LASTNAME_REQUIRED");
        RuleFor(x=>x.Owner.Username).NotEmpty().WithMessage("Owner username is required").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_USERNAME_REQUIRED");
        RuleFor(x=>x.Owner.Locale).NotEmpty().WithMessage("Owner locale is required").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_LOCALE_REQUIRED");
        RuleFor(x=>x.Owner.Email).NotEmpty().WithMessage("Owner email is required").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_EMAIL_REQUIRED");
        RuleFor(x=>x.Owner.Email).EmailAddress().WithMessage("Owner email is invalid").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_EMAIL_INVALID");
        RuleFor(x=>x.Owner.Password).NotEmpty().WithMessage("Owner password is required").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_PASSWORD_REQUIRED");
        RuleFor(x=>x.Owner.Password).MinimumLength(8).WithMessage("Owner password must be at least 8 characters").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_PASSWORD_MINIMUM_LENGTH");
        RuleFor(x=>x.Owner.Password).Matches("[A-Z]").WithMessage("Owner password must contain at least one uppercase letter").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_PASSWORD_UPPERCASE");
        RuleFor(x=>x.Owner.Password).Matches("[a-z]").WithMessage("Owner password must contain at least one lowercase letter").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_PASSWORD_LOWERCASE");
        RuleFor(x=>x.Owner.Password).Matches("[0-9]").WithMessage("Owner password must contain at least one number").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_PASSWORD_NUMBER");
        RuleFor(x=>x.Owner.Password).Matches("[^a-zA-Z0-9]").WithMessage("Owner password must contain at least one special character").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_OWNER_PASSWORD_SPECIAL_CHARACTER");
        
        
        RuleFor(x => x).Must( request =>
        {
            var organization =  organizationRepository
                .Queryable
                .FirstOrDefault(c => c.Name == request.Organization.Name);
            
            return organization == null;
        }).WithMessage("Organization name already exists").WithErrorCode("IDENTITIES_ORGANIZATION_SAVE_NAME_ALREADY_EXISTS");
    }
    
}