using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;
public class SaveOrganizationPreValidator : AbstractValidator<SaveOrganizationRequest>
{
    public SaveOrganizationPreValidator(
        IRepository<Organization, ObjectId> organizationRepository)
    {
        RuleFor(x => x.Organization)
            .NotNull()
            .WithMessage("Organization cannot be null")
            .MustAsync((organization, cancellationToken) =>
            {
                var query = organizationRepository.Queryable.Where(x => x.Name == organization.Name);
                return Task.FromResult(!query.Any());
            })
            .WithMessage("Organization exists yet");


        RuleFor(x => x.Owner)
            .NotNull()
            .WithMessage("Owner cannot be null");
        
        
        RuleFor(x => x.Owner.Email)
            .NotNull()
            .WithMessage("Email's Owner cannot be null");
        
        RuleFor(x => x.Owner.Username)
            .NotNull()
            .WithMessage("Username's Owner cannot be null");
    }
}