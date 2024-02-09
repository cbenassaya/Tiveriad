
using FluentValidation;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class ScopeSaveCommandHandlerValidator : AbstractValidator<ScopeSaveCommandHandlerRequest>
{
    private IRepository<Scope, string> _repository;
    public ScopeSaveCommandHandlerValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Scope).NotNull().WithErrorCode(ErrorCodes.ScopeSaveCommandHandler_Scope_XNotNullRule);
    }


}

