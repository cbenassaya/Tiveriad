#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.PolicyQueries;

public class PolicyGetByIdQueryHandlerValidator : AbstractValidator<PolicyGetByIdQueryHandlerRequest>
{
    private IRepository<Policy, string> _repository;

    public PolicyGetByIdQueryHandlerValidator(IRepository<Policy, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.PolicyGetByIdQueryHandler_Id_XNotNullRule);
    }
}