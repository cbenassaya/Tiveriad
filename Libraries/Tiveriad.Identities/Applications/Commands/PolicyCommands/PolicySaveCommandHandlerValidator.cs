#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public class PolicySaveCommandHandlerValidator : AbstractValidator<PolicySaveCommandHandlerRequest>
{
    private IRepository<Policy, string> _repository;

    public PolicySaveCommandHandlerValidator(IRepository<Policy, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Policy).NotNull().WithErrorCode(ErrorCodes.PolicySaveCommandHandler_Policy_XNotNullRule);
    }
}