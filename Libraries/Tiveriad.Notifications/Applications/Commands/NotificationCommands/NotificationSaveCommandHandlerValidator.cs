
using FluentValidation;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class NotificationSaveCommandHandlerValidator : AbstractValidator<NotificationSaveCommandHandlerRequest>
{
    private IRepository<Notification, string> _repository;
    public NotificationSaveCommandHandlerValidator(IRepository<Notification, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Notification).NotNull().WithErrorCode(ErrorCodes.NotificationSaveCommandHandler_Notification_XNotNullRule);
        RuleFor(x => x.Notification.UserId).NotEmpty().WithErrorCode(ErrorCodes.Notification_UserId_XNotEmptyRule);
    }


}

