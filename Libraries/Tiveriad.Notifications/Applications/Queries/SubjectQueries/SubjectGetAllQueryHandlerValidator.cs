
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Notifications.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public class SubjectGetAllQueryHandlerValidator : AbstractValidator<SubjectGetAllQueryHandlerRequest>
{
    private IRepository<Subject, string> _repository;
    public SubjectGetAllQueryHandlerValidator(IRepository<Subject, string> repository)
    {
        _repository = repository;


    }


}

