#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.PolicyQueries;

public record PolicyGetAllQueryHandlerRequest(
    string? RealmId = null,
    string? RoleId = null,
    string? Id = null,
    string? Name = null,
    int? Page = null,
    int? Limit = null,
    string? Q = null,
    IEnumerable<string>? Orders = null) : IRequest<PagedResult<Policy>>;