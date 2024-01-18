using MediatR;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.DomainEvents;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Multitenancy.Core.Exceptions;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;

public class UpdateOrganizationRequestHandler : IRequestHandler<UpdateOrganizationRequest, Organization>
{
    private readonly IRepository<Organization, ObjectId> _organizationRepository;
    private readonly IDomainEventStore _store;
    public UpdateOrganizationRequestHandler(IRepository<Organization, ObjectId> organizationRepository, IDomainEventStore store)
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
            if (result == null)
            {
                throw new MultiTenancyException(MultiTenancyError.BAD_REQUEST);
            }
            else
            {
                result.Name = request.Organization.Name;
                result.Description = request.Organization.Description;
                result.State = request.Organization.State;
                _store.Add<OrganizationDomainEvent,string>( new OrganizationDomainEvent() {Organization = result, EventType = "UPDATE"});
                return result;
            }
            //<-- END CUSTOM CODE-->
        }, cancellationToken);
    }
}