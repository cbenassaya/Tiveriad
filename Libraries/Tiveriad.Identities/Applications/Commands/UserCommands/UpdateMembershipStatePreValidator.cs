#region

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UpdateMembershipStatePreValidator : AbstractValidator<UpdateMembershipStateRequest>
{
    public UpdateMembershipStatePreValidator(
        IRepository<User, string> userRepository,
        IRepository<Organization, string> organizationRepository,
        IRepository<Client, string> clientRepository,
        IRepository<Membership, string> membershipRepository)
    {
        RuleFor(x => x.OrganizationId)
            .NotNull().NotEmpty()
            .WithMessage("OrganizationId cannot be null or empty")
            .WithErrorCode("UPDATE_USER_ORGANIZATION_ID_REQUIRED");
        RuleFor(x => x.OrganizationId)
            .Must(id =>
            {
                var query = organizationRepository.Queryable.Where(o => o.Id == id);
                return query.FirstOrDefault() != null;
            }).WithMessage("Organization not exists").WithErrorCode("UPDATE_USER_ORGANIZATION_NOT_EXISTS");

        RuleFor(x => x.ClientId)
            .NotNull().NotEmpty()
            .WithMessage("ClientId cannot be null or empty").WithErrorCode("UPDATE_USER_CLIENT_ID_REQUIRED");
        RuleFor(x => x)
            .Must(request =>
            {
                var query = clientRepository.Queryable.Where(o =>
                    o.Id == request.ClientId && o.Organization.Id == request.OrganizationId);

                return query.FirstOrDefault() != null;
            }).WithMessage("Client not exists").WithErrorCode("UPDATE_USER_CLIENT_NOT_EXISTS");

        RuleFor(x => x.userId)
            .NotNull().NotEmpty()
            .WithMessage("UserId cannot be null or empty").WithErrorCode("UPDATE_USER_USER_ID_REQUIRED");

        RuleFor(x => x.membershipState)
            .NotNull().NotEmpty()
            .WithMessage("MembershipState cannot be null or empty")
            .WithErrorCode("UPDATE_USER_MEMBERSHIP_STATE_REQUIRED");

        RuleFor(x => x.membershipState)
            .Must(state => { return Enum.TryParse<MembershipState>(state, out var _); })
            .WithMessage("MembershipState is not valid").WithErrorCode("UPDATE_USER_MEMBERSHIP_STATE_NOT_VALID");

        RuleFor(x => x.userId)
            .Must(userId =>
            {
                var query = userRepository.Queryable.Where(x => x.Id == userId);
                return query.FirstOrDefault() != null;
            }).WithMessage("User not exists").WithErrorCode("UPDATE_USER_USER_NOT_EXISTS");

        RuleFor(x => x)
            .Must(request =>
            {
                var query = membershipRepository.Queryable
                    .Include(x => x.Organization)
                    .Include(x => x.User)
                    .Include(x => x.Client)
                    .Where(x => x.Organization.Id == request.OrganizationId && x.User.Id == request.userId &&
                                x.Client.Id == request.ClientId);
                return query.FirstOrDefault() != null;
            }).WithMessage("Membership not exists").WithErrorCode("UPDATE_USER_MEMBERSHIP_NOT_EXISTS");
    }
}