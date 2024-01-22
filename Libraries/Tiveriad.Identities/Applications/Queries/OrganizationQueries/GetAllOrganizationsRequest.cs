#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public record GetAllOrganizationsRequest(
    string? Id,
    string? Name,
    int? Page,
    int? Limit,
    string? Q,
    string[]? Orders) : IRequest<IEnumerable<Organization>>, IQueryRequest;