
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using System;
namespace Tiveriad.Notifications.Applications.Queries.NotificationQueries;

public record NotificationGetByIdQueryHandlerRequest(string Id) : IRequest<Notification?>;