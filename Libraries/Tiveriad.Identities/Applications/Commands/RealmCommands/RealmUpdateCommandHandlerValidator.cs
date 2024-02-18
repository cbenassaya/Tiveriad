#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RealmCommands;

public class RealmUpdateCommandHandlerValidator : AbstractValidator<RealmUpdateCommandHandlerRequest>
{
    private IRepository<Realm, string> _repository;

    public RealmUpdateCommandHandlerValidator(IRepository<Realm, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Realm).NotNull().WithErrorCode(ErrorCodes.RealmUpdateCommandHandler_Realm_XNotNullRule);
        RuleFor(x => x.Realm.Id).NotNull().WithErrorCode(ErrorCodes.Realm_Id_XNotNullRule);
        RuleFor(x => x.Realm.Name).MaximumLength(50).WithErrorCode(ErrorCodes.Realm_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Realm.Name).NotEmpty().WithErrorCode(ErrorCodes.Realm_Name_XNotEmptyRule);
        RuleFor(x => x.Realm.Description).MaximumLength(100)
            .WithErrorCode(ErrorCodes.Realm_Description_XMaxLengthRule_Max_100);
        RuleFor(x => x.Realm.Description).NotEmpty().WithErrorCode(ErrorCodes.Realm_Description_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Id != request.Realm.Id);
                    query = query.Where(x => x.Name == request.Realm.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Realm_Name_XUniqueRule);
    }
}