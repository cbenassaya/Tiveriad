#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RoleQueries;

public record RoleGetByIdQueryHandlerRequest(string OrganizationId, string Id) : IRequest<Role?>;