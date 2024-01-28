#region

using FluentValidation;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class GetAllUsersByOrganizationPreValidator : AbstractValidator<GetAllUsersByOrganizationRequest>
{
    public GetAllUsersByOrganizationPreValidator()
    {
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required")
            .WithErrorCode("GETALLUSERSBYORGANIZATION.ORGANIZATIONID.REQUIRED");
    }
}