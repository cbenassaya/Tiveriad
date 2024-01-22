#region

using MediatR;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Core.DomainEvents;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Core.Exceptions;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class UpdateOrganizationRequestHandler : IRequestHandler<UpdateOrganizationRequest, Organization>
{
    private readonly IRepository<Organization, string> _organizationRepository;
    private readonly IDomainEventStore _store;

    public UpdateOrganizationRequestHandler(IRepository<Organization, string> organizationRepository,
        IDomainEventStore store)
    {
        _organizationRepository = organizationRepository;
        _store = store;
    }

    public Task<Organization> Handle(UpdateOrganizationRequest request, CancellationToken cancellationToken)
    {
        var query = _organizationRepository.Queryable.Where(x => x.Id == request.Organization.Id);
        return Task.Run(async () =>
        {
            //<-- START CUSTOM CODE-->
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new IdentitiesException(IdentitiesError.BAD_REQUEST);

            result.Name = request.Organization.Name;
            result.Description = request.Organization.Description;
            _store.Add<OrganizationDomainEvent, string>(new OrganizationDomainEvent
                { Organization = result, EventType = "UPDATE" });
            return result;
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}