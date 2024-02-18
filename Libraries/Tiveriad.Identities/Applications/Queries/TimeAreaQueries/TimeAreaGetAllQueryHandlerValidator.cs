#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.TimeAreaQueries;

public class TimeAreaGetAllQueryHandlerValidator : AbstractValidator<TimeAreaGetAllQueryHandlerRequest>
{
    private IRepository<TimeArea, string> _repository;

    public TimeAreaGetAllQueryHandlerValidator(IRepository<TimeArea, string> repository)
    {
        _repository = repository;
    }
}