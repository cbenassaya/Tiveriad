#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class RoleSaveCommandHandler : IRequestHandler<RoleSaveCommandHandlerRequest, Role>
{
    private IRepository<Organization, string> _organizationRepository;
    private readonly IRepository<Role, string> _roleRepository;

    public RoleSaveCommandHandler(IRepository<Role, string> roleRepository, IRepository<Organization, string> organizationRepository)
    {
        _roleRepository = roleRepository;
        _organizationRepository = organizationRepository;
    }


    public Task<Role> Handle(RoleSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            request.Role.Organization = _organizationRepository.GetById(request.OrganizationId);
            await _roleRepository.AddOneAsync(request.Role, cancellationToken);
            return request.Role;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}