
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Notifications.Applications.Queries.NotificationQueries;

public class NotificationGetAllQueryHandlerValidator : AbstractValidator<NotificationGetAllQueryHandlerRequest>
{
    private IRepository<Notification, string> _repository;
    public NotificationGetAllQueryHandlerValidator(IRepository<Notification, string> repository)
    {
        _repository = repository;


    }


}

