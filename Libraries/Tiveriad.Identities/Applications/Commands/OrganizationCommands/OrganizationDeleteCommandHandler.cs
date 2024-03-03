#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationDeleteCommandHandler : IRequestHandler<OrganizationDeleteCommandHandlerRequest, bool>
{
    private readonly IRepository<Organization, string> _organizationRepository;
    private IRepository<User, string> _userRepository;

    public OrganizationDeleteCommandHandler(IRepository<Organization, string> organizationRepository,
        IRepository<User, string> userRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
    }


    public Task<bool> Handle(OrganizationDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _organizationRepository.Queryable.AsQueryable();
            query = query.Where(x => x.Id == request.Id);


            var organization = query.FirstOrDefault();
            if (organization == null) throw new Exception();
            return _organizationRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}