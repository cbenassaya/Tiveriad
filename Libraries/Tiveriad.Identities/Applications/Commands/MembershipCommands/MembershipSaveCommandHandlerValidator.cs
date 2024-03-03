
using FluentValidation;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipSaveCommandHandlerValidator : AbstractValidator<MembershipSaveCommandHandlerRequest>
{
    private IRepository<Membership, string> _repository;
    public MembershipSaveCommandHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Membership).NotNull().WithErrorCode(ErrorCodes.MembershipSaveCommandHandler_Membership_XNotNullRule);
    }


}

