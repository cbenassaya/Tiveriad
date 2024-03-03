#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationUpdateCommandHandler : IRequestHandler<OrganizationUpdateCommandHandlerRequest, Organization>
{
    private readonly IRepository<Organization, string> _organizationRepository;
    private readonly IRepository<User, string> _userRepository;

    public OrganizationUpdateCommandHandler(IRepository<Organization, string> organizationRepository,
        IRepository<User, string> userRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
    }


    public Task<Organization> Handle(OrganizationUpdateCommandHandlerRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _organizationRepository.Queryable.Include(x => x.Owner).AsQueryable();

            query = query.Where(x => x.Id == request.Id);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();
            result.Name = request.Organization.Name;
            result.Domain = request.Organization.Domain;
            result.Description = request.Organization.Description;
            result.Properties = request.Organization.Properties;
            result.TimeZone = request.Organization.TimeZone;
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}