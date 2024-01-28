#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.NotificationQueries;

public class GetAllNotificationsPreValidator : AbstractValidator<GetAllNotificationsRequest>
{
    private IRepository<Notification, string> _repository;

    public GetAllNotificationsPreValidator(IRepository<Notification, string> repository)
    {
        _repository = repository;
    }
}