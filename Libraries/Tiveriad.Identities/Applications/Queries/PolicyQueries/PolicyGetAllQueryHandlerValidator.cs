#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.PolicyQueries;

public class PolicyGetAllQueryHandlerValidator : AbstractValidator<PolicyGetAllQueryHandlerRequest>
{
    private IRepository<Policy, string> _repository;

    public PolicyGetAllQueryHandlerValidator(IRepository<Policy, string> repository)
    {
        _repository = repository;
    }
}