#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserDeleteCommandHandlerValidator : AbstractValidator<UserDeleteCommandHandlerRequest>
{
    private IRepository<User, string> _repository;

    public UserDeleteCommandHandlerValidator(IRepository<User, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.UserDeleteCommandHandler_Id_XNotNullRule);
    }
}