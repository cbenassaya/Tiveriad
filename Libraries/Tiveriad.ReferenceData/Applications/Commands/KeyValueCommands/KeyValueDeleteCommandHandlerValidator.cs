
using FluentValidation;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.ReferenceData.Core.Entities;
namespace Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;

public class KeyValueDeleteCommandHandlerValidator : AbstractValidator<KeyValueDeleteCommandHandlerRequest>
{
    private IRepository<KeyValue, string> _repository;
    public KeyValueDeleteCommandHandlerValidator(IRepository<KeyValue, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.OrganizationId).NotNull().WithErrorCode(ErrorCodes.KeyValue_OrganizationId_XNotNullRule);
        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.KeyValueDeleteCommandHandler_Id_XNotNullRule);
    }


}

