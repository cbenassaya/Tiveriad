#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.ClientQueries;

public record GetAllClientsRequest(
    string? Id,
    string? OrganizationId,
    string? Name,
    int? Page,
    int? Limit,
    string? Q,
    string[]? Orders) : IRequest<IEnumerable<Client>>, IQueryRequest;