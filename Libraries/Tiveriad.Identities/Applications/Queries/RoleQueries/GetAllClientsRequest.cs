#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public record GetAllRolesRequest(
    string? Id,
    string? OrganizationId,
    string? ClientId,
    string? Name,
    int? Page,
    int? Limit,
    string? Q,
    string[]? Orders) : IRequest<IEnumerable<Role>>, IQueryRequest;