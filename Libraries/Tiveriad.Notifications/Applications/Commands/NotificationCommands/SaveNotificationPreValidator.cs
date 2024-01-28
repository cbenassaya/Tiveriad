#region

using FluentValidation;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class SaveNotificationPreValidator : AbstractValidator<SaveNotificationRequest>
{
    private IRepository<Notification, string> _repository;

    public SaveNotificationPreValidator(IRepository<Notification, string> repository)
    {
        _repository = repository;
    }
}