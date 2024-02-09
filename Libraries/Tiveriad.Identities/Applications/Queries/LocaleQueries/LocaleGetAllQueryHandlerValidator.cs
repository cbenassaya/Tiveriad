
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Queries.LocaleQueries;

public class LocaleGetAllQueryHandlerValidator : AbstractValidator<LocaleGetAllQueryHandlerRequest>
{
    private IRepository<Locale, string> _repository;
    public LocaleGetAllQueryHandlerValidator(IRepository<Locale, string> repository)
    {
        _repository = repository;


    }


}

