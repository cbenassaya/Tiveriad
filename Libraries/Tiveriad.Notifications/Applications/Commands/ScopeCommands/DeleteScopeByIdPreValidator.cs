#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class DeleteScopeByIdPreValidator : AbstractValidator<DeleteScopeByIdRequest>
{
    private IRepository<Scope, string> _repository;

    public DeleteScopeByIdPreValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;
    }
}