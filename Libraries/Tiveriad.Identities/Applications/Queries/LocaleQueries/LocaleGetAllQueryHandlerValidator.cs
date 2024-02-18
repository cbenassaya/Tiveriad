#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LocaleQueries;

public class LocaleGetAllQueryHandlerValidator : AbstractValidator<LocaleGetAllQueryHandlerRequest>
{
    private IRepository<Locale, string> _repository;

    public LocaleGetAllQueryHandlerValidator(IRepository<Locale, string> repository)
    {
        _repository = repository;
    }
}