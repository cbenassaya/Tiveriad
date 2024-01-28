#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public record GetRoleByIdRequest(
    string Id,
    string OrganizationId,
    string ClientId
) : IRequest<Role?>, IQueryRequest;