using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;

public class UpdateOrganizationPreValidator : AbstractValidator<UpdateOrganizationRequest>
{
    private IRepository<Organization, ObjectId> _organizationRepository;
    public UpdateOrganizationPreValidator(IRepository<Organization, ObjectId> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }
}