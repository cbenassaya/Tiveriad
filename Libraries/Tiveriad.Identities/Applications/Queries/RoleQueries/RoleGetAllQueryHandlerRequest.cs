#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public record RoleGetAllQueryHandlerRequest(
    string? OrganizationId = null,
    string? Id = null,
    string? Name = null,
    int? Page = null,
    int? Limit = null,
    string? Q = null,
    IEnumerable<string>? Orders = null) : IRequest<List<Role>>;