#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.TimeAreaQueries;

public class TimeAreaGetByIdQueryHandlerValidator : AbstractValidator<TimeAreaGetByIdQueryHandlerRequest>
{
    private IRepository<TimeArea, string> _repository;

    public TimeAreaGetByIdQueryHandlerValidator(IRepository<TimeArea, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.TimeAreaGetByIdQueryHandler_Id_XNotNullRule);
    }
}