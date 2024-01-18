using MediatR;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Queries.OrganizationQueries;
public class GetOrganizationByIdRequestHandler : IRequestHandler<GetOrganizationByIdRequest, Organization>
{
    private readonly IRepository<Organization, ObjectId> _organizationRepository;
    public GetOrganizationByIdRequestHandler(IRepository<Organization, ObjectId> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public Task<Organization> Handle(GetOrganizationByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _organizationRepository.Queryable.Where(x => x.Id.Equals(request.Id));
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}