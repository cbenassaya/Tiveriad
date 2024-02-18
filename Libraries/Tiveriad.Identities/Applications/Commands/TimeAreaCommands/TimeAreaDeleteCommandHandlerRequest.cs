#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public record TimeAreaDeleteCommandHandlerRequest(string Id) : IRequest<bool>;