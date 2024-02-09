
using MediatR;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public record ScopeSaveCommandHandlerRequest(Scope Scope) : IRequest<Scope>;