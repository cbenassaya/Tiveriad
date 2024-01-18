using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Queries.OrganizationQueries;
public class GetAllOrganizationsPreValidator : AbstractValidator<GetAllOrganizationsRequest>
{
    private IRepository<Organization, ObjectId> _organizationRepository;
    public GetAllOrganizationsPreValidator(IRepository<Organization, ObjectId> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }
}