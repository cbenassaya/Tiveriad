#region

using FluentValidation;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public class GetAllRolesPreValidator : AbstractValidator<GetAllRolesRequest>
{
    public GetAllRolesPreValidator()
    {
        RuleFor(x => x.ClientId).NotEmpty().WithMessage("ClientId is required")
            .WithErrorCode("IDENTITIES_ROLE_GETALL_CLIENTID_REQUIRED");
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required")
            .WithErrorCode("IDENTITIES_ROLE_GETALL_ORGANIZATIONID_REQUIRED");
    }
}