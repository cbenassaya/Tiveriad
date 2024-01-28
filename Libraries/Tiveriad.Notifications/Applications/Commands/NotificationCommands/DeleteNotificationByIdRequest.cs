#region

using MediatR;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public record DeleteNotificationByIdRequest(string Id) : IRequest<bool>;