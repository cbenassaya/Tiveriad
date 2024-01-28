#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Application.Queries.NotificationQueries;

public record GetAllNotificationsRequest(string? Id, int? Page, int? Limit, string? Q, IEnumerable<string>? Orders)
    : IRequest<IEnumerable<Notification>?>;