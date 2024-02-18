#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RealmQueries;

public class RealmGetAllQueryHandlerValidator : AbstractValidator<RealmGetAllQueryHandlerRequest>
{
    private IRepository<Realm, string> _repository;

    public RealmGetAllQueryHandlerValidator(IRepository<Realm, string> repository)
    {
        _repository = repository;
    }
}