#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public record RoleDeleteCommandHandlerRequest(string OrganizationId, string Id) : IRequest<bool>;
