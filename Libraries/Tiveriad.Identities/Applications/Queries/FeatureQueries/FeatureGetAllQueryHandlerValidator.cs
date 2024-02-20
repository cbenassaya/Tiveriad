#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.FeatureQueries;

public class FeatureGetAllQueryHandlerValidator : AbstractValidator<FeatureGetAllQueryHandlerRequest>
{
    private IRepository<Feature, string> _repository;

    public FeatureGetAllQueryHandlerValidator(IRepository<Feature, string> repository)
    {
        _repository = repository;
    }
}