
using FluentValidation;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Queries.LocaleQueries;

public class LocaleGetByIdQueryHandlerValidator : AbstractValidator<LocaleGetByIdQueryHandlerRequest>
{
    private IRepository<Locale, string> _repository;
    public LocaleGetByIdQueryHandlerValidator(IRepository<Locale, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.LocaleGetByIdQueryHandler_Id_XNotNullRule);
    }


}

