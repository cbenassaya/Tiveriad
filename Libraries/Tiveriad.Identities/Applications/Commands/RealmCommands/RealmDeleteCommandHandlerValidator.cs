#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RealmCommands;

public class RealmDeleteCommandHandlerValidator : AbstractValidator<RealmDeleteCommandHandlerRequest>
{
    private IRepository<Realm, string> _repository;

    public RealmDeleteCommandHandlerValidator(IRepository<Realm, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.RealmDeleteCommandHandler_Id_XNotNullRule);
    }
}