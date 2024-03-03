
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public class MembershipGetAllQueryHandlerValidator : AbstractValidator<MembershipGetAllQueryHandlerRequest>
{
    private IRepository<Membership, string> _repository;
    public MembershipGetAllQueryHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;


    }


}

