#region

using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class GetOrganizationByIdRequestHandler : IRequestHandler<GetOrganizationByIdRequest, Organization>
{
    private readonly IRepository<Organization, string> _organizationRepository;

    public GetOrganizationByIdRequestHandler(IRepository<Organization, string> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public Task<Organization> Handle(GetOrganizationByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _organizationRepository.Queryable.Where(x => x.Id == request.Id);
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
    }
}