
using FluentValidation;
using MediatR;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Notifications.Applications.Queries.NotificationQueries;

public class NotificationGetByIdQueryHandlerValidator : AbstractValidator<NotificationGetByIdQueryHandlerRequest>
{
    private IRepository<Notification, string> _repository;
    public NotificationGetByIdQueryHandlerValidator(IRepository<Notification, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.NotificationGetByIdQueryHandler_Id_XNotNullRule);
    }


}

