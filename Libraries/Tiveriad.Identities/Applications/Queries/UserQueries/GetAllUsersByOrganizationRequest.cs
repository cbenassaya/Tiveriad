using MediatR;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public record GetAllUsersByOrganizationRequest(
    string OrganizationId,
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