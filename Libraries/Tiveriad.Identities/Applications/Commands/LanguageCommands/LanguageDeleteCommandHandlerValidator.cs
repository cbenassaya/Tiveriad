
using FluentValidation;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public class LanguageDeleteCommandHandlerValidator : AbstractValidator<LanguageDeleteCommandHandlerRequest>
{
    private IRepository<Language, string> _repository;
    public LanguageDeleteCommandHandlerValidator(IRepository<Language, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.LanguageDeleteCommandHandler_Id_XNotNullRule);
    }


}

