
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Notifications.Applications.Queries.ScopeQueries;

public class ScopeGetAllQueryHandlerValidator : AbstractValidator<ScopeGetAllQueryHandlerRequest>
{
    private IRepository<Scope, string> _repository;
    public ScopeGetAllQueryHandlerValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;


    }


}

