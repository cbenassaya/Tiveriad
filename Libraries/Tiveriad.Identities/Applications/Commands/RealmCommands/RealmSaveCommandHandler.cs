#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RealmCommands;

public class RealmSaveCommandHandler : IRequestHandler<RealmSaveCommandHandlerRequest, Realm>
{
    private IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Realm, string> _realmRepository;

    public RealmSaveCommandHandler(IRepository<Realm, string> realmRepository,
        IRepository<Feature, string> featureRepository)
    {
        _realmRepository = realmRepository;
        _featureRepository = featureRepository;
    }


    public Task<Realm> Handle(RealmSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _realmRepository.AddOneAsync(request.Realm, cancellationToken);
            return request.Realm;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}