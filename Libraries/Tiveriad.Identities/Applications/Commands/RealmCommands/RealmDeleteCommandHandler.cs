#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RealmCommands;

public class RealmDeleteCommandHandler : IRequestHandler<RealmDeleteCommandHandlerRequest, bool>
{
    private IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Realm, string> _realmRepository;

    public RealmDeleteCommandHandler(IRepository<Realm, string> realmRepository,
        IRepository<Feature, string> featureRepository)
    {
        _realmRepository = realmRepository;
        _featureRepository = featureRepository;
    }


    public Task<bool> Handle(RealmDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _realmRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);


            var realm = query.FirstOrDefault();
            if (realm == null) throw new Exception();
            return _realmRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}