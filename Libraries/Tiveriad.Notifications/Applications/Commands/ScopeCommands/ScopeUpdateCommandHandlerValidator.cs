
using FluentValidation;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class ScopeUpdateCommandHandlerValidator : AbstractValidator<ScopeUpdateCommandHandlerRequest>
{
    private IRepository<Scope, string> _repository;
    public ScopeUpdateCommandHandlerValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Scope).NotNull().WithErrorCode(ErrorCodes.ScopeUpdateCommandHandler_Scope_XNotNullRule);
        RuleFor(x => x.Scope.Id).NotNull().WithErrorCode(ErrorCodes.Scope_Id_XNotNullRule);
    }


}

