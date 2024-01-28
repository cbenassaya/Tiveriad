#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class DeleteRoleByIdPreValidator : AbstractValidator<DeleteRoleByIdRequest>
{
    public DeleteRoleByIdPreValidator(IRepository<Role, string> roleRepository)
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").WithErrorCode("IDENTITIES_ROLE_DELETE_ID_REQUIRED");
        RuleFor(x => x.ClientId).NotEmpty().WithMessage("ClientId is required")
            .WithErrorCode("IDENTITIES_ROLE_DELETE_CLIENTID_REQUIRED");
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required")
            .WithErrorCode("IDENTITIES_ROLE_DELETE_ORGANIZATIONID_REQUIRED");
        RuleFor(x => x).Must(request =>
        {
            var role = roleRepository
                .Queryable
                .FirstOrDefault(c =>
                    c.Id == request.Id && c.Client.Id == request.ClientId &&
                    c.Client.Organization.Id == request.OrganizationId);

            return role != null;
        }).WithMessage("Role not found").WithErrorCode("IDENTITIES_ROLE_DELETE_NOT_FOUND");
    }
}