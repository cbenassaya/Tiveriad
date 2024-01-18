using MediatR;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.DomainEvents;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.UserCommands;
public class SaveUserRequestHandler : IRequestHandler<SaveUserRequest, User>
{
    private readonly IRepository<User, ObjectId> _userRepository;
    private readonly IRepository<Membership,ObjectId> _membershipRepository;
    private readonly IRepository<Organization,ObjectId> _organizationRepository;
    
    private readonly IDomainEventStore _store;
    public SaveUserRequestHandler(IRepository<User, ObjectId> userRepository, IDomainEventStore store, IRepository<Membership, ObjectId> membershipRepository, IRepository<Organization, ObjectId> organizationRepository)
    {
        _userRepository = userRepository;
        _store = store;
        _membershipRepository = membershipRepository;
        _organizationRepository = organizationRepository;
    }

    public Task<User> Handle(SaveUserRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            var organization = await _organizationRepository.GetByIdAsync(request.OrganizationId,cancellationToken);
            //<-- START CUSTOM CODE-->
            var user =  await _userRepository.GetByIdAsync(request.User.Id, cancellationToken);
            if (user == null)
            {
                user = request.User;
                await _userRepository.AddOneAsync(user, cancellationToken);
            }
            else
            {
                user.Email = request.User.Email;
                user.Firstname = request.User.Firstname;
                user.Lastname = request.User.Lastname;
                user.Description = request.User.Description;
                user.Username = request.User.Username;
                await _userRepository.UpdateOneAsync(user, cancellationToken);
            }
            var membership = new Membership()
            {
                OrganizationId = organization.Id,
                UserId = user.Id,
                State = MembershipState.Pending
            };
            await _membershipRepository.AddOneAsync(membership, cancellationToken);
            _store.Add<MembershipDomainEvent, string>(new MembershipDomainEvent() { Membership = membership, EventType = "SAVE" });
            return user;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}