
using FluentValidation;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public class MembershipGetByIdQueryHandlerValidator : AbstractValidator<MembershipGetByIdQueryHandlerRequest>
{
    private IRepository<Membership, string> _repository;
    public MembershipGetByIdQueryHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.MembershipGetByIdQueryHandler_Id_XNotNullRule);
    }


}

