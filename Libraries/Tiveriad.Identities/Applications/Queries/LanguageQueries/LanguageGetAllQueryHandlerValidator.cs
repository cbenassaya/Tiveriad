#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LanguageQueries;

public class LanguageGetAllQueryHandlerValidator : AbstractValidator<LanguageGetAllQueryHandlerRequest>
{
    private IRepository<Language, string> _repository;

    public LanguageGetAllQueryHandlerValidator(IRepository<Language, string> repository)
    {
        _repository = repository;
    }
}