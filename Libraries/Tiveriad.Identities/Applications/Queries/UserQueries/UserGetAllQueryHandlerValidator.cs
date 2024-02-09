
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class UserGetAllQueryHandlerValidator : AbstractValidator<UserGetAllQueryHandlerRequest>
{
    private IRepository<User, string> _repository;
    public UserGetAllQueryHandlerValidator(IRepository<User, string> repository)
    {
        _repository = repository;


    }


}

