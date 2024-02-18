#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public record UserDeleteCommandHandlerRequest(string Id) : IRequest<bool>;