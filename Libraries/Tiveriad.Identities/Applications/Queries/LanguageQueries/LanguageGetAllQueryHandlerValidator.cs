
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Queries.LanguageQueries;

public class LanguageGetAllQueryHandlerValidator : AbstractValidator<LanguageGetAllQueryHandlerRequest>
{
    private IRepository<Language, string> _repository;
    public LanguageGetAllQueryHandlerValidator(IRepository<Language, string> repository)
    {
        _repository = repository;


    }


}

