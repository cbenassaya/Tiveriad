using MediatR;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.DomainEvents;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Multitenancy.Core.Exceptions;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.UserCommands;

public class UpdateMembershipStateRequestHandler : IRequestHandler<UpdateMembershipStateRequest, User>
{
    private readonly IRepository<Membership, ObjectId> _membershipRepository;
    private readonly IDomainEventStore _store;
    private readonly IRepository<User, ObjectId> _userRepository;
    public UpdateMembershipStateRequestHandler(IRepository<Membership, ObjectId> membershipRepository, IDomainEventStore store, IRepository<User, ObjectId> userRepository)
    {
        _membershipRepository = membershipRepository;
        _store = store;
        _userRepository = userRepository;
    }

    public Task<User> Handle(UpdateMembershipStateRequest request, CancellationToken cancellationToken)
    {
      
        return Task.Run(async () =>
        {
            var query =  _membershipRepository.Queryable
                .Where(x => x.OrganizationId.Equals(request.OrganizationId) && x.UserId.Equals(request.userId));
            var result = query.ToList().FirstOrDefault();
            if (result == null)
                throw new MultiTenancyException(MultiTenancyError.BAD_REQUEST);
            result.State = request.state;
            _store.Add<MembershipDomainEvent, string>(new MembershipDomainEvent() { Membership = result, EventType = "UPDATE" });
            return await _userRepository.GetByIdAsync(request.userId, cancellationToken);
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}