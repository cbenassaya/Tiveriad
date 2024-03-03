#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public class PolicySaveCommandHandler : IRequestHandler<PolicySaveCommandHandlerRequest, Policy>
{
    private IRepository<Feature, string> _featureRepository;
    private readonly IRepository<Policy, string> _policyRepository;
    private IRepository<Realm, string> _realmRepository;
    private IRepository<Role, string> _roleRepository;

    public PolicySaveCommandHandler(IRepository<Policy, string> policyRepository,
        IRepository<Realm, string> realmRepository, IRepository<Role, string> roleRepository,
        IRepository<Feature, string> featureRepository)
    {
        _policyRepository = policyRepository;
        _realmRepository = realmRepository;
        _roleRepository = roleRepository;
        _featureRepository = featureRepository;
    }


    public Task<Policy> Handle(PolicySaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            if (request.Policy.Realm != null)
                request.Policy.Realm = await _realmRepository.GetByIdAsync(request.RealmId, cancellationToken);
            if (request.Policy.Role != null)
                request.Policy.Role = await _roleRepository.GetByIdAsync(request.RoleId, cancellationToken);
            if (request.Policy.Features != null)
                request.Policy.Features =
                    request.Policy.Features.Select(x=>
                        _featureRepository.GetByIdAsync(x.Id, cancellationToken).Result
                        ).ToList();
            await _policyRepository.AddOneAsync(request.Policy, cancellationToken);
            return request.Policy;
        }, cancellationToken);
        
    }
}