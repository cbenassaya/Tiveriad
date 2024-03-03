
using FluentValidation;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipUpdateCommandHandlerValidator : AbstractValidator<MembershipUpdateCommandHandlerRequest>
{
    private IRepository<Membership, string> _repository;
    public MembershipUpdateCommandHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.MembershipUpdateCommandHandler_Id_XNotNullRule);
        RuleFor(x => x.Membership).NotNull().WithErrorCode(ErrorCodes.MembershipUpdateCommandHandler_Membership_XNotNullRule);
    }


}

