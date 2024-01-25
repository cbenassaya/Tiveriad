#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public record GetOrganizationByIdRequest(string Id) : IRequest<Organization?>, IQueryRequest;