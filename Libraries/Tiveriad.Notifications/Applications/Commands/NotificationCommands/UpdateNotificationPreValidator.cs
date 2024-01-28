#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class UpdateNotificationPreValidator : AbstractValidator<UpdateNotificationRequest>
{
    private IRepository<Notification, string> _repository;

    public UpdateNotificationPreValidator(IRepository<Notification, string> repository)
    {
        _repository = repository;
    }
}