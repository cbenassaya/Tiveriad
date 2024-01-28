#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Application.Queries.NotificationQueries;

public record GetNotificationByIdRequest(string Id) : IRequest<Notification?>;