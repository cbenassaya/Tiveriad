#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class RoleSaveCommandHandler : IRequestHandler<RoleSaveCommandHandlerRequest, Role>
{
    private IRepository<Realm, string> _realmRepository;
    private readonly IRepository<Role, string> _roleRepository;

    public RoleSaveCommandHandler(IRepository<Role, string> roleRepository, IRepository<Realm, string> realmRepository)
    {
        _roleRepository = roleRepository;
        _realmRepository = realmRepository;
    }


    public Task<Role> Handle(RoleSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _roleRepository.AddOneAsync(request.Role, cancellationToken);
            return request.Role;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}