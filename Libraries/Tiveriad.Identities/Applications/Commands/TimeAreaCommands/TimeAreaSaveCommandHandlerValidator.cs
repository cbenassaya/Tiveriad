#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public class TimeAreaSaveCommandHandlerValidator : AbstractValidator<TimeAreaSaveCommandHandlerRequest>
{
    private IRepository<TimeArea, string> _repository;

    public TimeAreaSaveCommandHandlerValidator(IRepository<TimeArea, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.TimeArea).NotNull().WithErrorCode(ErrorCodes.TimeAreaSaveCommandHandler_TimeArea_XNotNullRule);
        RuleFor(x => x.TimeArea.Name).MaximumLength(50).WithErrorCode(ErrorCodes.TimeArea_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.TimeArea.Name).NotEmpty().WithErrorCode(ErrorCodes.TimeArea_Name_XNotEmptyRule);
        RuleFor(x => x.TimeArea.Code).MaximumLength(24).WithErrorCode(ErrorCodes.TimeArea_Code_XMaxLengthRule_Max_24);
        RuleFor(x => x.TimeArea.Code).NotEmpty().WithErrorCode(ErrorCodes.TimeArea_Code_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Name == request.TimeArea.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.TimeArea_Name_XUniqueRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Code == request.TimeArea.Code);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.TimeArea_Code_XUniqueRule);
    }
}