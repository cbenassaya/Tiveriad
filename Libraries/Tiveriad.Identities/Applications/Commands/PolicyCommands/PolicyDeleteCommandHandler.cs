#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public class PolicyDeleteCommandHandler : IRequestHandler<PolicyDeleteCommandHandlerRequest, bool>
{
    private IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Policy, string> _policyRepository;
    private IRepository<Realm, string> _realmRepository;
    private IRepository<Role, string> _roleRepository;

    public PolicyDeleteCommandHandler(IRepository<Policy, string> policyRepository,
        IRepository<Realm, string> realmRepository, IRepository<Role, string> roleRepository,
        IRepository<Feature, string> featureRepository)
    {
        _policyRepository = policyRepository;
        _realmRepository = realmRepository;
        _roleRepository = roleRepository;
        _featureRepository = featureRepository;
    }


    public Task<bool> Handle(PolicyDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _policyRepository.Queryable.Include(x => x.Realm)
                .Include(x => x.Role)
                .Include(x => x.Feature).AsQueryable();
            query = query.Where(x => x.Id == request.Id);


            var policy = query.FirstOrDefault();
            if (policy == null) throw new Exception();
            return _policyRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}