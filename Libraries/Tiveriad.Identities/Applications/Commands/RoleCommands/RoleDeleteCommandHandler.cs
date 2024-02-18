#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class RoleDeleteCommandHandler : IRequestHandler<RoleDeleteCommandHandlerRequest, bool>
{
    private IRepository<Realm, string> _realmRepository;
    private readonly IRepository<Role, string> _roleRepository;

    public RoleDeleteCommandHandler(IRepository<Role, string> roleRepository,
        IRepository<Realm, string> realmRepository)
    {
        _roleRepository = roleRepository;
        _realmRepository = realmRepository;
    }


    public Task<bool> Handle(RoleDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _roleRepository.Queryable.Include(x => x.Realm).AsQueryable();
            query = query.Where(x => x.Id == request.Id);


            var role = query.FirstOrDefault();
            if (role == null) throw new Exception();
            return _roleRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}