#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class SaveRolePreValidator : AbstractValidator<SaveRoleRequest>
{
    public SaveRolePreValidator(IRepository<Role, string> roleRepository)
    {
        RuleFor(x => x.Role).NotNull().WithMessage("Role is required")
            .WithErrorCode("IDENTITIES_ROLE_SAVE_ROLE_REQUIRED");
        RuleFor(x => x.Role.Name).NotEmpty().WithMessage("Name is required")
            .WithErrorCode("IDENTITIES_ROLE_SAVE_NAME_REQUIRED");
        RuleFor(x => x.ClientId).NotEmpty().WithMessage("ClientId is required")
            .WithErrorCode("IDENTITIES_ROLE_SAVE_CLIENTID_REQUIRED");
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required")
            .WithErrorCode("IDENTITIES_ROLE_SAVE_ORGANIZATIONID_REQUIRED");
        RuleFor(x => x).Must(request =>
        {
            var role = roleRepository
                .Queryable
                .FirstOrDefault(c =>
                    c.Name == request.Role.Name && c.Client.Id == request.ClientId &&
                    c.Client.Organization.Id == request.OrganizationId);

            return role == null;
        }).WithMessage("Role name already exists").WithErrorCode("IDENTITIES_ROLE_SAVE_NAME_ALREADY_EXISTS");
    }
}