
using FluentValidation;
using MediatR;
using Tiveriad.ReferenceData.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.ReferenceData.Applications.Queries.KeyValueQueries;

public class KeyValueGetByIdQueryHandlerValidator : AbstractValidator<KeyValueGetByIdQueryHandlerRequest>
{
    private IRepository<KeyValue, string> _repository;
    public KeyValueGetByIdQueryHandlerValidator(IRepository<KeyValue, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.OrganizationId).NotNull().WithErrorCode(ErrorCodes.OrganizationId_XNotNullRule);
        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.KeyValueGetByIdQueryHandler_Id_XNotNullRule);
    }


}

