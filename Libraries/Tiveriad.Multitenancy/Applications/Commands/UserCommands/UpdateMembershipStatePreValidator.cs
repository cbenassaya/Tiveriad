using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.UserCommands;

public class UpdateMembershipStatePreValidator : AbstractValidator<UpdateMembershipStateRequest>
{
    public UpdateMembershipStatePreValidator(IRepository<User, ObjectId> userRepository, IRepository<Organization,ObjectId> organizationRepository)
    {
        RuleFor(x => x.OrganizationId)
            .NotNull().NotEmpty()
            .WithMessage("OrganizationId cannot be null or empty");
        
        
        RuleFor(x => x.userId)      
            .NotNull().NotEmpty()
            .WithMessage("userId cannot be null or empty");

    }
}