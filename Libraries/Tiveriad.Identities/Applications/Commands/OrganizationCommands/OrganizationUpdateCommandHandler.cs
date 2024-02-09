
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationUpdateCommandHandler : IRequestHandler<OrganizationUpdateCommandHandlerRequest, Organization>
{
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<User, string> _userRepository;
    private IRepository<TimeArea, string> _timeAreaRepository;
    public OrganizationUpdateCommandHandler(IRepository<Organization, string> organizationRepository, IRepository<User, string> userRepository, IRepository<TimeArea, string> timeAreaRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
        _timeAreaRepository = timeAreaRepository;

    }


    public Task<Organization> Handle(OrganizationUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _organizationRepository.Queryable.Include(x => x.Owner)
    .Include(x => x.TimeArea).AsQueryable();



            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.Organization.Name;
            result.Logo = request.Organization.Logo;
            result.Domain = request.Organization.Domain;
            result.Description = request.Organization.Description;
            result.State = request.Organization.State;
            result.Properties = request.Organization.Properties;
            if (request.Organization.Owner != null) result.Owner = await _userRepository.GetByIdAsync(request.Organization.Owner.Id, cancellationToken);
            if (request.Organization.TimeArea != null) result.TimeArea = await _timeAreaRepository.GetByIdAsync(request.Organization.TimeArea.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

