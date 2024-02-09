
using FluentValidation;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationModelQueries;

public class RegistrationModelGetByIdQueryHandlerValidator : AbstractValidator<RegistrationModelGetByIdQueryHandlerRequest>
{
    private IRepository<RegistrationModel, string> _repository;
    public RegistrationModelGetByIdQueryHandlerValidator(IRepository<RegistrationModel, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.RegistrationModelGetByIdQueryHandler_Id_XNotNullRule);
    }


}

