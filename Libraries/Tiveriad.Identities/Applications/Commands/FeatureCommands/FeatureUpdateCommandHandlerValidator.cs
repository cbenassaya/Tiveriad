#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.FeatureCommands;

public class FeatureUpdateCommandHandlerValidator : AbstractValidator<FeatureUpdateCommandHandlerRequest>
{
    private IRepository<Feature, string> _repository;

    public FeatureUpdateCommandHandlerValidator(IRepository<Feature, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotEmpty().WithErrorCode(ErrorCodes.FeatureUpdateCommandHandler_Id_XNotEmptyRule);
        RuleFor(x => x.Feature).NotNull().WithErrorCode(ErrorCodes.FeatureUpdateCommandHandler_Feature_XNotNullRule);
        RuleFor(x => x.Feature.Name).MaximumLength(50).WithErrorCode(ErrorCodes.Feature_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Feature.Name).NotEmpty().WithErrorCode(ErrorCodes.Feature_Name_XNotEmptyRule);
        RuleFor(x => x.Feature.Code).MaximumLength(24).WithErrorCode(ErrorCodes.Feature_Code_XMaxLengthRule_Max_24);
        RuleFor(x => x.Feature.Code).NotEmpty().WithErrorCode(ErrorCodes.Feature_Code_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Id != request.Id);
                    query = query.Where(x => x.Name == request.Feature.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Feature_Name_XUniqueRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Id != request.Id);
                    query = query.Where(x => x.Code == request.Feature.Code);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Feature_Code_XUniqueRule);
    }
}