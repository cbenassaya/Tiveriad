
using MediatR;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public record NotificationSaveCommandHandlerRequest(Notification Notification) : IRequest<Notification>;