
using FluentValidation;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public class LocaleDeleteCommandHandlerValidator : AbstractValidator<LocaleDeleteCommandHandlerRequest>
{
    private IRepository<Locale, string> _repository;
    public LocaleDeleteCommandHandlerValidator(IRepository<Locale, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.LocaleDeleteCommandHandler_Id_XNotNullRule);
    }


}
