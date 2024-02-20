#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipUpdateCommandHandlerValidator : AbstractValidator<MembershipUpdateCommandHandlerRequest>
{
    private IRepository<Membership, string> _repository;

    public MembershipUpdateCommandHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;
        RuleFor(x => x.Id).NotEmpty()
            .WithErrorCode(ErrorCodes.MembershipUpdateCommandHandler_Id_XNotEmptyRule);
        RuleFor(x => x.Membership).NotNull()
            .WithErrorCode(ErrorCodes.MembershipUpdateCommandHandler_Membership_XNotNullRule);
        
        RuleFor(x => x.Membership)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Id != request.Id);
                    query = query.Where(x => x.User.Id == request.User.Id);
                    query = query.Where(x => x.Organization.Id == request.Organization.Id);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.MembershipSaveCommandHandler_Membership_XUniqueRule);
    }
}