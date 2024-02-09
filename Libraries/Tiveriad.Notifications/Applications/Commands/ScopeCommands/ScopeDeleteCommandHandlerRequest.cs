
using MediatR;
using System;
namespace Tiveriad.Notifications.Applications.Commands.ScopeCommands;

public record ScopeDeleteCommandHandlerRequest(string Id) : IRequest<bool>;