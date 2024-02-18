#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class UserGetAllQueryHandlerValidator : AbstractValidator<UserGetAllQueryHandlerRequest>
{
    private IRepository<User, string> _repository;

    public UserGetAllQueryHandlerValidator(IRepository<User, string> repository)
    {
        _repository = repository;
    }
}