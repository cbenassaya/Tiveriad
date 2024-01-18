using MediatR;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.DomainEvents;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;
public class SaveOrganizationRequestHandler : IRequestHandler<SaveOrganizationRequest, Organization>
{
    private readonly IRepository<Organization, ObjectId> _organizationRepository;
    private readonly IRepository<User, ObjectId> _userRepository;
    private readonly IRepository<Membership, ObjectId> _memberShipRepository;
    private readonly IDomainEventStore _store;
    public SaveOrganizationRequestHandler(IRepository<Organization, ObjectId> organizationRepository, IDomainEventStore store, IRepository<User, ObjectId> userRepository, IRepository<Membership, ObjectId> memberShipRepository)
    {
        _organizationRepository = organizationRepository;
        _store = store;
        _userRepository = userRepository;
        _memberShipRepository = memberShipRepository;
    }

    public Task<Organization> Handle(SaveOrganizationRequest request, CancellationToken cancellationToken)
    {
        var query = _organizationRepository.Queryable.Where(x => x.Id == request.Organization.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            await _organizationRepository.AddOneAsync(request.Organization, cancellationToken);
            var owner =  _userRepository.Queryable.FirstOrDefault(x => x.Email == request.Owner.Email || x.Username == request.Owner.Username);
            if (owner == null)
            {
                owner = request.Owner;
                await _userRepository.AddOneAsync(owner, cancellationToken);
            }
            var  membership = new Membership()
            {
                OrganizationId = request.Organization.Id,
                UserId = owner.Id,
                State = MembershipState.Validated,
                IsOwner = true
            };
            await _memberShipRepository.AddOneAsync(membership, cancellationToken);
            _store.Add<MembershipDomainEvent,string>( new MembershipDomainEvent() {Membership = membership, EventType = "INSERT"});
            return request.Organization;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}