#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.ClientQueries;

public class GetAllClientsPreValidator : AbstractValidator<GetAllClientsRequest>
{

    public GetAllClientsPreValidator()
    {
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required").WithErrorCode("IDENTITIES_CLIENT_GETALL_ORGANIZATIONID_REQUIRED");
    }
}