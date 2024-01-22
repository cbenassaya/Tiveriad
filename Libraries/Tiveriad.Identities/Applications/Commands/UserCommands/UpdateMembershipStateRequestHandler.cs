#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Core.Exceptions;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UpdateMembershipStateRequestHandler : IRequestHandler<UpdateMembershipStateRequest, User>
{
    private readonly IRepository<Membership, string> _membershipRepository;
    private readonly IDomainEventStore _store;

    public UpdateMembershipStateRequestHandler(IRepository<Membership, string> membershipRepository,
        IDomainEventStore store)
    {
        _membershipRepository = membershipRepository;
        _store = store;
    }

    public Task<User> Handle(UpdateMembershipStateRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            var query = _membershipRepository.Queryable.Include(x => x.Organization).Include(x => x.User)
                .Where(x => x.Organization.Id == request.OrganizationId && x.User.Id == request.userId);
            var result = query.ToList().FirstOrDefault();
            if (result == null)
                throw new IdentitiesException(IdentitiesError.BAD_REQUEST);
            result.State = request.state;
            _store.Add<MembershipDomainEvent, string>(new MembershipDomainEvent
                { Membership = result, EventType = "UPDATE" });
            return result.User;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}