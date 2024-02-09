
using FluentValidation;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Notifications.Applications.Queries.ScopeQueries;

public class ScopeGetByIdQueryHandlerValidator : AbstractValidator<ScopeGetByIdQueryHandlerRequest>
{
    private IRepository<Scope, string> _repository;
    public ScopeGetByIdQueryHandlerValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.ScopeGetByIdQueryHandler_Id_XNotNullRule);
    }


}

