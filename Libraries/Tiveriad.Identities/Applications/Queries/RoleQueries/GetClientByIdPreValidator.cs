#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public class GetRoleByIdPreValidator : AbstractValidator<GetRoleByIdRequest>
{

    public GetRoleByIdPreValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").WithErrorCode("IDENTITIES_ROLE_GET_ID_REQUIRED");
        RuleFor(x => x.ClientId).NotEmpty().WithMessage("ClientId is required").WithErrorCode("IDENTITIES_ROLE_GET_CLIENTID_REQUIRED");
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required").WithErrorCode("IDENTITIES_ROLE_GET_ORGANIZATIONID_REQUIRED");
    }
}