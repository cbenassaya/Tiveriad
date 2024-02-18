#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LanguageQueries;

public class LanguageGetByIdQueryHandlerValidator : AbstractValidator<LanguageGetByIdQueryHandlerRequest>
{
    private IRepository<Language, string> _repository;

    public LanguageGetByIdQueryHandlerValidator(IRepository<Language, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.LanguageGetByIdQueryHandler_Id_XNotNullRule);
    }
}