#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.PolicyQueries;

public record PolicyGetByIdQueryHandlerRequest(string RealmId, string RoleId, string Id) : IRequest<Policy?>;