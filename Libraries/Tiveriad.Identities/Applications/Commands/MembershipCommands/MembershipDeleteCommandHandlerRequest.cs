#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public record MembershipDeleteCommandHandlerRequest(string Id) : IRequest<bool>;