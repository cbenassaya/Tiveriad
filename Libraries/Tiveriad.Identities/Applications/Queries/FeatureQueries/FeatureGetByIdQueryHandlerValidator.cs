#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.FeatureQueries;

public class FeatureGetByIdQueryHandlerValidator : AbstractValidator<FeatureGetByIdQueryHandlerRequest>
{
    private IRepository<Feature, string> _repository;

    public FeatureGetByIdQueryHandlerValidator(IRepository<Feature, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.FeatureGetByIdQueryHandler_Id_XNotNullRule);
    }
}