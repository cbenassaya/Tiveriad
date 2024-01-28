#region

using FluentValidation;

#endregion

namespace Tiveriad.Identities.Applications.Queries.ClientQueries;

public class GetClientByIdPreValidator : AbstractValidator<GetClientByIdRequest>
{
    public GetClientByIdPreValidator()
    {
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required")
            .WithErrorCode("IDENTITIES_CLIENT_GETALL_ORGANIZATIONID_REQUIRED");
    }
}