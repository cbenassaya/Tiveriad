#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UpdateMembershipStatePreValidator : AbstractValidator<UpdateMembershipStateRequest>
{
    public UpdateMembershipStatePreValidator(IRepository<User, string> userRepository,
        IRepository<Organization, string> organizationRepository)
    {
        RuleFor(x => x.OrganizationId)
            .NotNull().NotEmpty()
            .WithMessage("OrganizationId cannot be null or empty");


        RuleFor(x => x.userId)
            .NotNull().NotEmpty()
            .WithMessage("userId cannot be null or empty");
    }
}