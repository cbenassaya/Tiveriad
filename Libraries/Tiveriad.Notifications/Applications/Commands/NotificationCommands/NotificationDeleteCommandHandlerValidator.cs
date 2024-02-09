
using FluentValidation;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Applications.Commands.NotificationCommands;

public class NotificationDeleteCommandHandlerValidator : AbstractValidator<NotificationDeleteCommandHandlerRequest>
{
    private IRepository<Notification, string> _repository;
    public NotificationDeleteCommandHandlerValidator(IRepository<Notification, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.NotificationDeleteCommandHandler_Id_XNotNullRule);
    }


}

