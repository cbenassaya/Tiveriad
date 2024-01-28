#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public record UpdateNotificationRequest(string Id, Notification Notification) : IRequest<Notification>;