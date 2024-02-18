#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RealmCommands;

public record RealmDeleteCommandHandlerRequest(string Id) : IRequest<bool>;