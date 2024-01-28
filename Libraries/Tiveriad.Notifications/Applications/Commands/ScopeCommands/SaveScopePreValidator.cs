#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class SaveScopePreValidator : AbstractValidator<SaveScopeRequest>
{
    private IRepository<Scope, string> _repository;

    public SaveScopePreValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;
    }
}