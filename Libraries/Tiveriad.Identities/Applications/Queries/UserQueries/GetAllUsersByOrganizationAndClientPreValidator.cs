#region

using FluentValidation;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class
    GetAllUsersByOrganizationAndClientPreValidator : AbstractValidator<GetAllUsersByOrganizationAndClientRequest>
{
    public GetAllUsersByOrganizationAndClientPreValidator()
    {
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required")
            .WithErrorCode("GETALLUSERSBYORGANIZATIONANDCLIENT.ORGANIZATIONID.REQUIRED");
        RuleFor(x => x.ClientId).NotEmpty().WithMessage("ClientId is required")
            .WithErrorCode("GETALLUSERSBYORGANIZATIONANDCLIENT.CLIENTID.REQUIRED");
    }
}