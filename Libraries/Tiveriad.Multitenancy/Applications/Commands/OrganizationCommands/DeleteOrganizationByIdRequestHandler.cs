using MediatR;
using Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;
using Tiveriad.Multitenancy.Core.DomainEvents;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;
public class DeleteOrganizationByIdRequestHandler : IRequestHandler<DeleteOrganizationByIdRequest, bool>
{
    private readonly IRepository<Organization, ObjectId> _organizationRepository;
    private readonly IDomainEventStore _store;
    public DeleteOrganizationByIdRequestHandler(IRepository<Organization, ObjectId> organizationRepository, IDomainEventStore store)
    {
        _organizationRepository = organizationRepository;
        _store = store;
    }

    public Task<bool> Handle(DeleteOrganizationByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() =>
        {
            var organization = _organizationRepository.GetById(request.Id);
            var result =  _organizationRepository.DeleteOne(organization) == 1;
            if (result)
                _store.Add<OrganizationDomainEvent,string>( new OrganizationDomainEvent() {Organization = organization, EventType = "DELETE"});
            return result;
        }, cancellationToken);
    //<-- END CUSTOM CODE-->
    }
}