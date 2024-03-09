
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationUpdateCommandHandler : IRequestHandler<OrganizationUpdateCommandHandlerRequest, Organization>
{
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<User, string> _userRepository;
    public OrganizationUpdateCommandHandler(IRepository<Organization, string> organizationRepository, IRepository<User, string> userRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;

    }


    public Task<Organization> Handle(OrganizationUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            var query = _organizationRepository.Queryable.Include(x => x.Owner).AsQueryable();
            query = query.Where(x => x.Id == request.Id);


            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.Organization.Name;
            result.Logo = request.Organization.Logo;
            result.TimeZone = request.Organization.TimeZone;
            result.Domain = request.Organization.Domain;
            result.Description = request.Organization.Description;
            result.Properties = request.Organization.Properties;
            if (request.Organization.Owner != null) result.Owner = await _userRepository.GetByIdAsync(request.Organization.Owner.Id, cancellationToken);
            return result;
        }, cancellationToken);
    }
}

