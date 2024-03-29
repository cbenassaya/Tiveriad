
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class OrganizationGetAllQueryHandlerValidator : AbstractValidator<OrganizationGetAllQueryHandlerRequest>
{
    private IRepository<Organization, string> _repository;
    public OrganizationGetAllQueryHandlerValidator(IRepository<Organization, string> repository)
    {
        _repository = repository;


    }


}

