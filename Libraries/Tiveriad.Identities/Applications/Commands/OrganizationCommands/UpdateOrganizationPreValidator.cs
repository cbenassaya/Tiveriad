#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class UpdateOrganizationPreValidator : AbstractValidator<UpdateOrganizationRequest>
{
    public UpdateOrganizationPreValidator(IRepository<Organization, string> organizationRepository)
    {
        RuleFor(x => x.Organization).NotNull().WithMessage("Organization is required")
            .WithErrorCode("IDENTITIES_ORGANIZATION_UPDATE_ORGANIZATION_REQUIRED");
        RuleFor(x => x.Organization.Name).NotEmpty().WithMessage("Name is required")
            .WithErrorCode("IDENTITIES_ORGANIZATION_UPDATE_NAME_REQUIRED");
        RuleFor(x => x.Organization.Id).NotEmpty().WithMessage("Id is required")
            .WithErrorCode("IDENTITIES_ORGANIZATION_UPDATE_ID_REQUIRED");
        RuleFor(x => x).Must(request =>
        {
            var organization = organizationRepository
                .Queryable
                .FirstOrDefault(c => c.Id == request.Organization.Id);

            return organization != null;
        }).WithMessage("Organization not found").WithErrorCode("IDENTITIES_ORGANIZATION_UPDATE_NOT_FOUND");
        RuleFor(x => x).Must(request =>
            {
                var organization = organizationRepository
                    .Queryable
                    .FirstOrDefault(c => c.Name == request.Organization.Name && c.Id != request.Organization.Id);

                return organization == null;
            }).WithMessage("Organization name already exists")
            .WithErrorCode("IDENTITIES_ORGANIZATION_UPDATE_NAME_ALREADY_EXISTS");
    }
}