#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public record SaveScopeRequest(Scope Scope) : IRequest<Scope>;