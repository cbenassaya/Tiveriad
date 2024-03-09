#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RealmCommands;

public class RealmSaveCommandHandlerValidator : AbstractValidator<RealmSaveCommandHandlerRequest>
{
    private IRepository<Realm, string> _repository;

    public RealmSaveCommandHandlerValidator(IRepository<Realm, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Realm).NotNull().WithErrorCode(ErrorCodes.RealmSaveCommandHandler_Realm_XNotNullRule);
        RuleFor(x => x.Realm.Name).MaximumLength(50).WithErrorCode(ErrorCodes.Realm_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Realm.Name).NotEmpty().WithErrorCode(ErrorCodes.Realm_Name_XNotEmptyRule);
        RuleFor(x => x.Realm.Description).MaximumLength(100)
            .WithErrorCode(ErrorCodes.Realm_Description_XMaxLengthRule_Max_100);
        RuleFor(x => x.Realm.Description).NotEmpty().WithErrorCode(ErrorCodes.Realm_Description_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Name == request.Realm.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Realm_Name_XUniqueRule);
        RuleFor(x => x.Realm.Code).MaximumLength(24).WithErrorCode(ErrorCodes.Realm_Code_XMaxLengthRule_Max_24);
        RuleFor(x => x.Realm.Code).NotEmpty().WithErrorCode(ErrorCodes.Realm_Code_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Code == request.Realm.Code);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Realm_Code_XUniqueRule);
    }
}