using MediatR;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Applications.Queries.OrganizationQueries;

public record GetAllOrganizationsRequest(
    ObjectId? Id, string? Name,
    int? Page,  int? Limit,
    string? Q,  string[]? Orders) :IRequest<IEnumerable<Organization>>, IQueryRequest;