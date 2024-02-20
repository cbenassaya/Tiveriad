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
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _policyRepository.Queryable.Include(x => x.Realm)
                .Include(x => x.Role)
                .Include(x => x.Feature).AsQueryable();


            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            if (request.Policy.Realm != null)
                result.Realm = await _realmRepository.GetByIdAsync(request.Policy.Realm.Id, cancellationToken);
            if (request.Policy.Role != null)
                result.Role = await _roleRepository.GetByIdAsync(request.Policy.Role.Id, cancellationToken);
            if (request.Policy.Feature != null)
                result.Feature = await _featureRepository.GetByIdAsync(request.Policy.Feature.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}