
using MediatR;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public record ScopeUpdateCommandHandlerRequest(Scope Scope) : IRequest<Scope>;