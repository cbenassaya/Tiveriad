
using FluentValidation;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public class ScopeDeleteCommandHandlerValidator : AbstractValidator<ScopeDeleteCommandHandlerRequest>
{
    private IRepository<Scope, string> _repository;
    public ScopeDeleteCommandHandlerValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.ScopeDeleteCommandHandler_Id_XNotNullRule);
    }


}

