#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class GetOrganizationByIdPreValidator : AbstractValidator<GetOrganizationByIdRequest>
{
    private IRepository<Organization, string> _organizationRepository;

    public GetOrganizationByIdPreValidator(IRepository<Organization, string> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }
}