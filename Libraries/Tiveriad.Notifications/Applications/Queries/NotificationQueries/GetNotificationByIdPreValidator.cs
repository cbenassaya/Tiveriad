#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Application.Queries.NotificationQueries;

public class GetNotificationByIdPreValidator : AbstractValidator<GetNotificationByIdRequest>
{
    private IRepository<Notification, string> _repository;

    public GetNotificationByIdPreValidator(IRepository<Notification, string> repository)
    {
        _repository = repository;
    }
}