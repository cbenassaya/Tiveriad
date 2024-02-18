#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipDeleteCommandHandlerValidator : AbstractValidator<MembershipDeleteCommandHandlerRequest>
{
    private IRepository<Membership, string> _repository;

    public MembershipDeleteCommandHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.MembershipDeleteCommandHandler_Id_XNotNullRule);
    }
}