#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public record RoleDeleteCommandHandlerRequest(string Id) : IRequest<bool>;