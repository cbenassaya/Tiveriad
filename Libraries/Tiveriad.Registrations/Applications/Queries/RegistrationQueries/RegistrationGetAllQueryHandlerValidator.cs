
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Registrations.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationQueries;

public class RegistrationGetAllQueryHandlerValidator : AbstractValidator<RegistrationGetAllQueryHandlerRequest>
{
    private IRepository<Registration, string> _repository;
    public RegistrationGetAllQueryHandlerValidator(IRepository<Registration, string> repository)
    {
        _repository = repository;


    }


}

