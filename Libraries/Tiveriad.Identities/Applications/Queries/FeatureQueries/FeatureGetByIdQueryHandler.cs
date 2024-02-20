#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.FeatureQueries;

public class FeatureGetByIdQueryHandler : IRequestHandler<FeatureGetByIdQueryHandlerRequest, Feature?>
{
    private readonly IRepository<Feature, string> _languageRepository;

    public FeatureGetByIdQueryHandler(IRepository<Feature, string> languageRepository)
    {
        _languageRepository = languageRepository;
    }


    public Task<Feature?> Handle(FeatureGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _languageRepository.Queryable;
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => x.Realm.Id == request.RealmId);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}