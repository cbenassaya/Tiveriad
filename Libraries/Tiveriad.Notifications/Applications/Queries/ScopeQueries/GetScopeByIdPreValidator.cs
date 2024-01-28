#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.ScopeQueries;

public class GetScopeByIdPreValidator : AbstractValidator<GetScopeByIdRequest>
{
    private IRepository<Scope, string> _repository;

    public GetScopeByIdPreValidator(IRepository<Scope, string> repository)
    {
        _repository = repository;
    }
}