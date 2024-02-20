#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class RoleDeleteCommandHandlerValidator : AbstractValidator<RoleDeleteCommandHandlerRequest>
{
    private IRepository<Role, string> _repository;

    public RoleDeleteCommandHandlerValidator(IRepository<Role, string> repository)
    {
        _repository = repository;
        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.RoleDeleteCommandHandler_Id_XNotNullRule);
        RuleFor(x => x.OrganizationId).NotNull().WithErrorCode(ErrorCodes.RoleDeleteCommandHandler_OrganizationId_XNotNullRule);
    }
}