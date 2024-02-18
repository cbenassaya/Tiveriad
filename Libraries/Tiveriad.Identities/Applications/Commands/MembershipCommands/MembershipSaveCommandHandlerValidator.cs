#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipSaveCommandHandlerValidator : AbstractValidator<MembershipSaveCommandHandlerRequest>
{
    private IRepository<Membership, string> _repository;

    public MembershipSaveCommandHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Membership).NotNull()
            .WithErrorCode(ErrorCodes.MembershipSaveCommandHandler_Membership_XNotNullRule);
    }
}