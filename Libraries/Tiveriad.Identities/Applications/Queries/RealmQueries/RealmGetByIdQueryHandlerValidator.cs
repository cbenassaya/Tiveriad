#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RealmQueries;

public class RealmGetByIdQueryHandlerValidator : AbstractValidator<RealmGetByIdQueryHandlerRequest>
{
    private IRepository<Realm, string> _repository;

    public RealmGetByIdQueryHandlerValidator(IRepository<Realm, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.RealmGetByIdQueryHandler_Id_XNotNullRule);
    }
}