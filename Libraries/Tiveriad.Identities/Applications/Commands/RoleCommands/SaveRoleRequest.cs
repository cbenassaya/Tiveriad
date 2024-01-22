#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public record SaveRoleRequest(
    string OrganizationId,
    string ClientId,
    Role Role) : IRequest<Role>, ICommandRequest;