
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.ReferenceData.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.ReferenceData.Applications.Queries.KeyValueQueries;

public class KeyValueGetAllQueryHandlerValidator : AbstractValidator<KeyValueGetAllQueryHandlerRequest>
{
    private IRepository<KeyValue, string> _repository;
    public KeyValueGetAllQueryHandlerValidator(IRepository<KeyValue, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.OrganizationId).NotNull().WithErrorCode(ErrorCodes.OrganizationId_XNotNullRule);
    }


}

