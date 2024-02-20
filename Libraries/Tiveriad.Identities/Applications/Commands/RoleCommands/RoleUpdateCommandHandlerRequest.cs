#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public record RoleUpdateCommandHandlerRequest(string OrganizationId, string Id, Role Role) : IRequest<Role>;