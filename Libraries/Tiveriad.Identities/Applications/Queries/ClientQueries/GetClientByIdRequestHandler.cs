#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.ClientQueries;

public class GetClientByIdRequestHandler : IRequestHandler<GetClientByIdRequest, Client?>
{
    private readonly IRepository<Client, string> _clientRepository;

    public GetClientByIdRequestHandler(IRepository<Client, string> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public Task<Client?> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query =
            _clientRepository.Queryable
                .Include(x => x.Organization)
                .Where(x => x.Id == request.Id && x.Organization.Id == request.OrganizationId);
        //<-- END CUSTOM CODE-->
        return Task.Run(() => query.FirstOrDefault(), cancellationToken);
    }
}