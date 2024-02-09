
using FluentValidation;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationQueries;

public class RegistrationGetByIdQueryHandlerValidator : AbstractValidator<RegistrationGetByIdQueryHandlerRequest>
{
    private IRepository<Registration, string> _repository;
    public RegistrationGetByIdQueryHandlerValidator(IRepository<Registration, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.RegistrationGetByIdQueryHandler_Id_XNotNullRule);
    }


}

