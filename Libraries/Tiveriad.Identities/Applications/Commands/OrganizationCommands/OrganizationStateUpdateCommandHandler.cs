using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Core.StateMachines;

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationStateUpdateCommandHandler : IRequestHandler<OrganizationStateUpdateCommandHandlerRequest, Organization>
{
    private readonly IRepository<Organization, string> _organizationRepository;

    public OrganizationStateUpdateCommandHandler(IRepository<Organization, string> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }


    public Task<Organization> Handle(OrganizationStateUpdateCommandHandlerRequest request,
        CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            var query = _organizationRepository.Queryable.AsQueryable();
            query = query.Where(x => x.Id == request.Id);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();
            var sm = result.State.GetStateMachine();
            sm.Fire(request.Event);
            result.State = sm.GetCurrentState();
            return result;
        }, cancellationToken);
        
    }
}