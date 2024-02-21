#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public record PolicyDeleteCommandHandlerRequest(string RealmId, string RoleId, string Id) : IRequest<bool>;