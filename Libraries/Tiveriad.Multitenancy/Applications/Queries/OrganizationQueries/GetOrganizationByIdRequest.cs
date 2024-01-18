using MediatR;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Applications.Queries.OrganizationQueries;

public record GetOrganizationByIdRequest(ObjectId Id) : IRequest<Organization>, IQueryRequest;