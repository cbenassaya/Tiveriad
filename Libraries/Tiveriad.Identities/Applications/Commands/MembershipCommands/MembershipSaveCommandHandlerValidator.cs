#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.MembershipCommands;

public class MembershipSaveCommandHandlerValidator : AbstractValidator<MembershipSaveCommandHandlerRequest>
{
    private IRepository<Membership, string> _repository;

    public MembershipSaveCommandHandlerValidator(IRepository<Membership, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Membership).NotNull()
            .WithErrorCode(ErrorCodes.MembershipSaveCommandHandler_Membership_XNotNullRule);
        
        RuleFor(x => x.Membership)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.User.Id == request.User.Id);
                    query = query.Where(x => x.Organization.Id == request.Organization.Id);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.MembershipSaveCommandHandler_Membership_XUniqueRule);
        
    }
}