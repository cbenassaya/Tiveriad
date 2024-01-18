using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Queries.OrganizationQueries;
public class GetOrganizationByIdPreValidator : AbstractValidator<GetOrganizationByIdRequest>
{
    private IRepository<Organization, ObjectId> _organizationRepository;
    public GetOrganizationByIdPreValidator(IRepository<Organization, ObjectId> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }
}