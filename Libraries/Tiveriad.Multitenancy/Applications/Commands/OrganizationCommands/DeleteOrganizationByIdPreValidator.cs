using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;
public class DeleteOrganizationByIdPreValidator : AbstractValidator<DeleteOrganizationByIdRequest>
{
    private IRepository<Organization, ObjectId> _organizationRepository;
    public DeleteOrganizationByIdPreValidator(IRepository<Organization, ObjectId> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }
}