#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class GetAllOrganizationsPreValidator : AbstractValidator<GetAllOrganizationsRequest>
{
    private IRepository<Organization, string> _organizationRepository;

    public GetAllOrganizationsPreValidator(IRepository<Organization, string> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }
}