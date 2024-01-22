#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class UpdateRolePreValidator : AbstractValidator<UpdateRoleRequest>
{

    public UpdateRolePreValidator(IRepository<Role, string> roleRepository)
    {
        RuleFor(x => x.Role).NotNull().WithMessage("Role is required").WithErrorCode("IDENTITIES_ROLE_UPDATE_ROLE_REQUIRED");
        RuleFor(x => x.Role.Id).NotEmpty().WithMessage("Id is required").WithErrorCode("IDENTITIES_ROLE_UPDATE_ID_REQUIRED");
        RuleFor(x => x.Role.Name).NotEmpty().WithMessage("Name is required").WithErrorCode("IDENTITIES_ROLE_UPDATE_NAME_REQUIRED");
        RuleFor(x => x.ClientId).NotEmpty().WithMessage("ClientId is required").WithErrorCode("IDENTITIES_ROLE_UPDATE_CLIENTID_REQUIRED");
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("OrganizationId is required").WithErrorCode("IDENTITIES_ROLE_UPDATE_ORGANIZATIONID_REQUIRED");
        RuleFor(x => x).Must( request =>
        {
            var role =  roleRepository
                .Queryable
                .FirstOrDefault(c => c.Id == request.Role.Id  && c.Client.Id == request.ClientId && c.Client.Organization.Id == request.OrganizationId);
            
            return role != null;
        }).WithMessage("Role not found").WithErrorCode("IDENTITIES_ROLE_UPDATE_NOT_FOUND");
        RuleFor(x => x).Must( request =>
        {
            var role =  roleRepository
                .Queryable
                .FirstOrDefault(c => c.Id != request.Role.Id && c.Name == request.Role.Name && c.Client.Id == request.ClientId && c.Client.Organization.Id == request.OrganizationId);
            
            return role == null;
        }).WithMessage("Role name already exists").WithErrorCode("IDENTITIES_ROLE_UPDATE_NAME_ALREADY_EXISTS");
    }
}