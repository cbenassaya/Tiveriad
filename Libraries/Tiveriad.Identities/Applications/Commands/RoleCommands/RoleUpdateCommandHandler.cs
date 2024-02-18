#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class RoleUpdateCommandHandler : IRequestHandler<RoleUpdateCommandHandlerRequest, Role>
{
    private readonly IRepository<Realm, string> _realmRepository;
    private readonly IRepository<Role, string> _roleRepository;

    public RoleUpdateCommandHandler(IRepository<Role, string> roleRepository,
        IRepository<Realm, string> realmRepository)
    {
        _roleRepository = roleRepository;
        _realmRepository = realmRepository;
    }


    public Task<Role> Handle(RoleUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _roleRepository.Queryable.Include(x => x.Realm).AsQueryable();
            query = query.Where(x => x.Id == request.Role.Id);


            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.Role.Name;
            result.Description = request.Role.Description;
            if (request.Role.Realm != null)
                result.Realm = await _realmRepository.GetByIdAsync(request.Role.Realm.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}