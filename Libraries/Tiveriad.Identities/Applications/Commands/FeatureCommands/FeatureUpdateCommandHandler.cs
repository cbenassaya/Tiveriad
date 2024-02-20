#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.FeatureCommands;

public class FeatureUpdateCommandHandler : IRequestHandler<FeatureUpdateCommandHandlerRequest, Feature>
{
    private readonly IRepository<Feature, string> _languageRepository;
    private readonly IRepository<Realm, string> _realmRepository;

    public FeatureUpdateCommandHandler(IRepository<Feature, string> languageRepository, IRepository<Realm, string> realmRepository)
    {
        _languageRepository = languageRepository;
        _realmRepository = realmRepository;
    }


    public Task<Feature> Handle(FeatureUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _languageRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);
            query = query.Where(x => x.Realm.Id == request.RealmId);

            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.Feature.Name;
            result.Code = request.Feature.Code;
     
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}