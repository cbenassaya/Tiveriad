#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public class RoleGetByIdQueryHandlerValidator : AbstractValidator<RoleGetByIdQueryHandlerRequest>
{
    private IRepository<Role, string> _repository;

    public RoleGetByIdQueryHandlerValidator(IRepository<Role, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.RoleGetByIdQueryHandler_Id_XNotNullRule);
    }
}