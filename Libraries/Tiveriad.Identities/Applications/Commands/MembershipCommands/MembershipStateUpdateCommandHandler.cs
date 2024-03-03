using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Core.StateMachines;

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipStateUpdateCommandHandler : IRequestHandler<MembershipStateUpdateCommandHandlerRequest, Membership>
{
    private readonly IRepository<Membership, string> _membershipRepository;

    public MembershipStateUpdateCommandHandler(IRepository<Membership, string> membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }


    public Task<Membership> Handle(MembershipStateUpdateCommandHandlerRequest request,
        CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            var query = _membershipRepository.Queryable.AsQueryable();
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

public class DefaultMembershipUpdateCommandHandler : IRequestHandler<DefaultMembershipUpdateCommandHandlerRequest, Membership>
{
    private readonly IRepository<Membership, string> _membershipRepository;

    public DefaultMembershipUpdateCommandHandler(IRepository<Membership, string> membershipRepository)
    {
        _membershipRepository = membershipRepository;
    }


    public Task<Membership> Handle(DefaultMembershipUpdateCommandHandlerRequest request,
        CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            var query = _membershipRepository.Queryable.AsQueryable();
            query = query.Where(x => x.User.Id == request.UserId && x.Organization.Id == request.OrganizationId);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();
            result.Default = true;
            _membershipRepository.Find(x=> x.User.Id == request.UserId && x.Id!=result.Id).ToList()
                .ForEach(x => x.Default = false
                );
            return result;
        }, cancellationToken);
        
    }
}