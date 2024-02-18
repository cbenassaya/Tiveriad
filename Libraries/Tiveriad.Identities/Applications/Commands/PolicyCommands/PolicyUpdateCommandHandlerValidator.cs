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
        RuleFor(x => x.Policy.Name).MaximumLength(50).WithErrorCode(ErrorCodes.Policy_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Policy.Name).NotEmpty().WithErrorCode(ErrorCodes.Policy_Name_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Id != request.Policy.Id);
                    query = query.Where(x => x.Name == request.Policy.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Policy_Name_XUniqueRule);
    }
}