#region

using MediatR;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class SaveUserRequestHandler : IRequestHandler<SaveUserRequest, User>
{
    private readonly IRepository<Client, string> _clientRepository;
    private readonly IRepository<Membership, string> _membershipRepository;
    private readonly IRepository<Organization, string> _organizationRepository;

    private readonly IDomainEventStore _store;
    private readonly IRepository<User, string> _userRepository;


    public SaveUserRequestHandler(IRepository<User, string> userRepository, IDomainEventStore store,
        IRepository<Membership, string> membershipRepository, IRepository<Organization, string> organizationRepository,
        IRepository<Client, string> clientRepository)
    {
        _userRepository = userRepository;
        _store = store;
        _membershipRepository = membershipRepository;
        _organizationRepository = organizationRepository;
        _clientRepository = clientRepository;
    }

    public Task<User> Handle(SaveUserRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            var organization = await _organizationRepository.GetByIdAsync(request.OrganizationId, cancellationToken);
            var client = await _clientRepository.GetByIdAsync(request.ClientId, cancellationToken);
            //<-- START CUSTOM CODE-->
            var query = _userRepository.Queryable.Where(x =>
                x.Email == request.User.Email || x.Username == request.User.Username);
            var user = query.FirstOrDefault();

            if (user == null)
            {
                await _userRepository.AddOneAsync(request.User, cancellationToken);
                user = request.User;
            }


            var membership = new Membership
            {
                Organization = organization,
                User = user,
                State = MembershipState.Pending,
                Client = client
            };
            await _membershipRepository.AddOneAsync(membership, cancellationToken);
            _store.Add<MembershipDomainEvent, string>(new MembershipDomainEvent
                { Membership = membership, EventType = "SAVE" });
            return request.User;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}