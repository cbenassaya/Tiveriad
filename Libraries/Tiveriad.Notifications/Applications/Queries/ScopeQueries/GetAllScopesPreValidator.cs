#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.ScopeQueries;

public class GetAllScopesPreValidator : AbstractValidator<GetAllScopesRequest>
{
    private IRepository<Scope, string> _repository;

    public GetAllScopesPreValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;
    }
}