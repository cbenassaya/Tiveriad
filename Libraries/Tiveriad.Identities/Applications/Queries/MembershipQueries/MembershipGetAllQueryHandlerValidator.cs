#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public class MembershipGetAllQueryHandlerValidator : AbstractValidator<MembershipGetAllQueryHandlerRequest>
{
    private IRepository<Membership, string> _repository;

    public MembershipGetAllQueryHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;
    }
}