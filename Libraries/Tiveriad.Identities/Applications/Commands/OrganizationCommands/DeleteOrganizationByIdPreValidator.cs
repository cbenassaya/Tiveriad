#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class DeleteOrganizationByIdPreValidator : AbstractValidator<DeleteOrganizationByIdRequest>
{
    public DeleteOrganizationByIdPreValidator(IRepository<Organization, string> organizationRepository)
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required")
            .WithErrorCode("IDENTITIES_ORGANIZATION_DELETE_ID_REQUIRED");
        RuleFor(x => x).Must(request =>
        {
            var organization = organizationRepository
                .Queryable
                .FirstOrDefault(c => c.Id == request.Id);

            return organization != null;
        }).WithMessage("Organization not found").WithErrorCode("IDENTITIES_ORGANIZATION_DELETE_NOT_FOUND");
    }
}