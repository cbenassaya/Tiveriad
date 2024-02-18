#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipUpdateCommandHandlerValidator : AbstractValidator<MembershipUpdateCommandHandlerRequest>
{
    private IRepository<Membership, string> _repository;

    public MembershipUpdateCommandHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Membership).NotNull()
            .WithErrorCode(ErrorCodes.MembershipUpdateCommandHandler_Membership_XNotNullRule);
        RuleFor(x => x.Membership.Id).NotNull().WithErrorCode(ErrorCodes.Membership_Id_XNotNullRule);
    }
}