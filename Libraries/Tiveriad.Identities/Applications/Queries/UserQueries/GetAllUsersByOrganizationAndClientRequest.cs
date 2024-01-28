#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public record GetAllUsersByOrganizationAndClientRequest(
    string OrganizationId,
    string ClientId,
    string? Id,
    string? Email,
    string? Username,
    string? Firstname,
    string? Lastname,
    string[]? States,
    int? Page,
    int? Limit,
    string? Q,
    string[]? Orders
) : IRequest<IEnumerable<User>>;