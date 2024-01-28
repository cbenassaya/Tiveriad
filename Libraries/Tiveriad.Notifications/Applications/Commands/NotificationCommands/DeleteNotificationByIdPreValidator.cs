#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class DeleteNotificationByIdPreValidator : AbstractValidator<DeleteNotificationByIdRequest>
{
    private IRepository<Notification, string> _repository;

    public DeleteNotificationByIdPreValidator(IRepository<Notification, string> repository)
    {
        _repository = repository;
    }
}