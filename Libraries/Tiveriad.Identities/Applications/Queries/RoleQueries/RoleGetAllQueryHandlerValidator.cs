#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public class RoleGetAllQueryHandlerValidator : AbstractValidator<RoleGetAllQueryHandlerRequest>
{
    private IRepository<Role, string> _repository;

    public RoleGetAllQueryHandlerValidator(IRepository<Role, string> repository)
    {
        _repository = repository;
    }
}