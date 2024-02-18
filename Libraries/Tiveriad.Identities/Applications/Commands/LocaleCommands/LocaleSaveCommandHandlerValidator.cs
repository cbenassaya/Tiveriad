#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.LocaleCommands;

public class LocaleSaveCommandHandlerValidator : AbstractValidator<LocaleSaveCommandHandlerRequest>
{
    private IRepository<Locale, string> _repository;

    public LocaleSaveCommandHandlerValidator(IRepository<Locale, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Locale).NotNull().WithErrorCode(ErrorCodes.LocaleSaveCommandHandler_Locale_XNotNullRule);
        RuleFor(x => x.Locale.Name).MaximumLength(50).WithErrorCode(ErrorCodes.Locale_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Locale.Name).NotEmpty().WithErrorCode(ErrorCodes.Locale_Name_XNotEmptyRule);
        RuleFor(x => x.Locale.Code).MaximumLength(24).WithErrorCode(ErrorCodes.Locale_Code_XMaxLengthRule_Max_24);
        RuleFor(x => x.Locale.Code).NotEmpty().WithErrorCode(ErrorCodes.Locale_Code_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Name == request.Locale.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Locale_Name_XUniqueRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Code == request.Locale.Code);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Locale_Code_XUniqueRule);
    }
}