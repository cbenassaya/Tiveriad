#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public record PolicyDeleteCommandHandlerRequest(string Id) : IRequest<bool>;