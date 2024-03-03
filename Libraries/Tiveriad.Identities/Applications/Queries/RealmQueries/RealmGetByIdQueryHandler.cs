#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RealmQueries;

public class RealmGetByIdQueryHandler : IRequestHandler<RealmGetByIdQueryHandlerRequest, Realm?>
{
    private IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Realm, string> _realmRepository;

    public RealmGetByIdQueryHandler(IRepository<Realm, string> realmRepository,
        IRepository<Feature, string> featureRepository)
    {
        _realmRepository = realmRepository;
        _featureRepository = featureRepository;
    }


    public Task<Realm?> Handle(RealmGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        
        var query = _realmRepository.Queryable;
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        
    }
}