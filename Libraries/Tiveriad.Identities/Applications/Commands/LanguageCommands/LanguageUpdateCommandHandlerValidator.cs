
using FluentValidation;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
namespace Tiveriad.Identities.Applications.Commands.LanguageCommands;

public class LanguageUpdateCommandHandlerValidator : AbstractValidator<LanguageUpdateCommandHandlerRequest>
{
    private IRepository<Language, string> _repository;
    public LanguageUpdateCommandHandlerValidator(IRepository<Language, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Language).NotNull().WithErrorCode(ErrorCodes.LanguageUpdateCommandHandler_Language_XNotNullRule);
        RuleFor(x => x.Language.Id).NotNull().WithErrorCode(ErrorCodes.Language_Id_XNotNullRule);
        RuleFor(x => x.Language.Name).MaximumLength(50).WithErrorCode(ErrorCodes.Language_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Language.Name).NotEmpty().WithErrorCode(ErrorCodes.Language_Name_XNotEmptyRule);
        RuleFor(x => x.Language.Code).MaximumLength(24).WithErrorCode(ErrorCodes.Language_Code_XMaxLengthRule_Max_24);
        RuleFor(x => x.Language.Code).NotEmpty().WithErrorCode(ErrorCodes.Language_Code_XNotEmptyRule);
        RuleFor(x => x)
        .Must(request =>
        {
            var query = repository.Queryable;
            query = query.Where(x => x.Name == request.Language.Name);
            return !query.ToList().Any();
        }
        ).WithErrorCode(ErrorCodes.Language_Name_XUniqueRule);
        RuleFor(x => x)
        .Must(request =>
        {
            var query = repository.Queryable;
            query = query.Where(x => x.Code == request.Language.Code);
            return !query.ToList().Any();
        }
        ).WithErrorCode(ErrorCodes.Language_Code_XUniqueRule);
    }


}

