#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RealmCommands;

public class RealmUpdateCommandHandler : IRequestHandler<RealmUpdateCommandHandlerRequest, Realm>
{
    private IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Realm, string> _realmRepository;

    public RealmUpdateCommandHandler(IRepository<Realm, string> realmRepository,
        IRepository<Feature, string> featureRepository)
    {
        _realmRepository = realmRepository;
        _featureRepository = featureRepository;
    }


    public Task<Realm> Handle(RealmUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            var query = _realmRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.Realm.Name;
            result.Description = request.Realm.Description;
            result.Properties = request.Realm.Properties;

            return result;
        }, cancellationToken);
        
    }
}