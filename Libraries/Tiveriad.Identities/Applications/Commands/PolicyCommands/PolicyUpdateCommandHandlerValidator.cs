#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public class PolicyUpdateCommandHandlerValidator : AbstractValidator<PolicyUpdateCommandHandlerRequest>
{
    private IRepository<Policy, string> _repository;

    public PolicyUpdateCommandHandlerValidator(IRepository<Policy, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Policy).NotNull().WithErrorCode(ErrorCodes.PolicyUpdateCommandHandler_Policy_XNotNullRule);
        RuleFor(x => x.Policy.Id).NotNull().WithErrorCode(ErrorCodes.Policy_Id_XNotNullRule);
    }
}