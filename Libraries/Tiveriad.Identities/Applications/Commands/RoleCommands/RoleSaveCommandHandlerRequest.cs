#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public record RoleSaveCommandHandlerRequest(Role Role) : IRequest<Role>;