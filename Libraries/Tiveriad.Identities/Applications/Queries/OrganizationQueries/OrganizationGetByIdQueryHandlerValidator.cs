
using FluentValidation;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public class OrganizationGetByIdQueryHandlerValidator : AbstractValidator<OrganizationGetByIdQueryHandlerRequest>
{
    private IRepository<Organization, string> _repository;
    public OrganizationGetByIdQueryHandlerValidator(IRepository<Organization, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.OrganizationGetByIdQueryHandler_Id_XNotNullRule);
    }


}

