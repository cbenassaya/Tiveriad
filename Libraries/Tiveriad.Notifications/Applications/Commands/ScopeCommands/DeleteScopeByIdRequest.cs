#region

using MediatR;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public record DeleteScopeByIdRequest(string Id) : IRequest<bool>;