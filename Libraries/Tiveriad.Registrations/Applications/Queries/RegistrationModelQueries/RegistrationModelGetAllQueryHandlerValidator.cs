
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Registrations.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationModelQueries;

public class RegistrationModelGetAllQueryHandlerValidator : AbstractValidator<RegistrationModelGetAllQueryHandlerRequest>
{
    private IRepository<RegistrationModel, string> _repository;
    public RegistrationModelGetAllQueryHandlerValidator(IRepository<RegistrationModel, string> repository)
    {
        _repository = repository;


    }


}

