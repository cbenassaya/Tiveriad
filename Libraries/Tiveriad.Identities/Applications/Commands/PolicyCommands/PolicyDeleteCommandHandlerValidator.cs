#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public class PolicyDeleteCommandHandlerValidator : AbstractValidator<PolicyDeleteCommandHandlerRequest>
{
    private IRepository<Policy, string> _repository;

    public PolicyDeleteCommandHandlerValidator(IRepository<Policy, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.PolicyDeleteCommandHandler_Id_XNotNullRule);
    }
}