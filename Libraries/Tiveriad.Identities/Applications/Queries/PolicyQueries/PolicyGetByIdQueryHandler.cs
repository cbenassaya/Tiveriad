#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.PolicyQueries;

public class PolicyGetByIdQueryHandler : IRequestHandler<PolicyGetByIdQueryHandlerRequest, Policy?>
{
    private IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Policy, string> _policyRepository;
    private IRepository<Realm, string> _realmRepository;
    private IRepository<Role, string> _roleRepository;

    public PolicyGetByIdQueryHandler(IRepository<Policy, string> policyRepository,
        IRepository<Realm, string> realmRepository, IRepository<Role, string> roleRepository,
        IRepository<Feature, string> featureRepository)
    {
        _policyRepository = policyRepository;
        _realmRepository = realmRepository;
        _roleRepository = roleRepository;
        _featureRepository = featureRepository;
    }


    public Task<Policy?> Handle(PolicyGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        
        var query = _policyRepository.Queryable.Include(x => x.Realm)
            .Include(x => x.Role)
            .Include(x => x.Features).AsQueryable();
        query = query.Where(x => x.Id == request.Id);
        query = query.Where(x => x.Role.Id == request.RoleId);
        query = query.Where(x => x.Realm.Id == request.RealmId);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        
    }
}