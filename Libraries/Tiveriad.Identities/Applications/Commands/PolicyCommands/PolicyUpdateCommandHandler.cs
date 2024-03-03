#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public class PolicyUpdateCommandHandler : IRequestHandler<PolicyUpdateCommandHandlerRequest, Policy>
{
    private readonly IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Policy, string> _policyRepository;
    private readonly IRepository<Realm, string> _realmRepository;
    private readonly IRepository<Role, string> _roleRepository;

    public PolicyUpdateCommandHandler(IRepository<Policy, string> policyRepository,
        IRepository<Realm, string> realmRepository, IRepository<Role, string> roleRepository,
        IRepository<Feature, string> featureRepository)
    {
        _policyRepository = policyRepository;
        _realmRepository = realmRepository;
        _roleRepository = roleRepository;
        _featureRepository = featureRepository;
    }


    public Task<Policy> Handle(PolicyUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            var query = _policyRepository.Queryable.Include(x => x.Realm)
                .Include(x => x.Role)
                .Include(x => x.Features).AsQueryable();
            query = query.Where(x => x.Id == request.Id);
            query = query.Where(x => x.Role.Id == request.RoleId);
            query = query.Where(x => x.Realm.Id == request.RealmId);

            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            if (request.Policy.Features != null)
            {
                request.Policy.Features.RemoveAll(x=>true);
                request.Policy.Features =
                    request.Policy.Features.Select(x=>
                        _featureRepository.GetByIdAsync(x.Id, cancellationToken).Result
                    ).ToList();
            }

            return result;
        }, cancellationToken);
        
    }
}