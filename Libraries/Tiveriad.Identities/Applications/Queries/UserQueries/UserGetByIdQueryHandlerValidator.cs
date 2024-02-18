#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class UserGetByIdQueryHandlerValidator : AbstractValidator<UserGetByIdQueryHandlerRequest>
{
    private IRepository<User, string> _repository;

    public UserGetByIdQueryHandlerValidator(IRepository<User, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.UserGetByIdQueryHandler_Id_XNotNullRule);
    }
}