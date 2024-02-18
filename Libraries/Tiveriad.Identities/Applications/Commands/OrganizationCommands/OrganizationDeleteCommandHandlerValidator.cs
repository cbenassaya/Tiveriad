#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationDeleteCommandHandlerValidator : AbstractValidator<OrganizationDeleteCommandHandlerRequest>
{
    private IRepository<Organization, string> _repository;

    public OrganizationDeleteCommandHandlerValidator(IRepository<Organization, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.OrganizationDeleteCommandHandler_Id_XNotNullRule);
    }
}