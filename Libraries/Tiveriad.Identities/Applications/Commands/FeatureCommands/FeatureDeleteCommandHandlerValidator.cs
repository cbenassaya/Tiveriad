#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.FeatureCommands;

public class FeatureDeleteCommandHandlerValidator : AbstractValidator<FeatureDeleteCommandHandlerRequest>
{
    private IRepository<Feature, string> _repository;

    public FeatureDeleteCommandHandlerValidator(IRepository<Feature, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.FeatureDeleteCommandHandler_Id_XNotNullRule);
    }
}