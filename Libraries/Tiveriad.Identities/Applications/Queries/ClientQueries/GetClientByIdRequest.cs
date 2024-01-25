#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.ClientQueries;

public record GetClientByIdRequest(string Id, string OrganizationId) : IRequest<Client?>, IQueryRequest;