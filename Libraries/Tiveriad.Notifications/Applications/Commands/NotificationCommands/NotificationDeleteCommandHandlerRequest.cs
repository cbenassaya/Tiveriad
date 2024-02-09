
using MediatR;
using System;
namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public record NotificationDeleteCommandHandlerRequest(string Id) : IRequest<bool>;