#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class UpdateScopePreValidator : AbstractValidator<UpdateScopeRequest>
{
    private IRepository<Scope, string> _repository;

    public UpdateScopePreValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;
    }
}