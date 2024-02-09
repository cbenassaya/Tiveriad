
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationSaveCommandHandler : IRequestHandler<OrganizationSaveCommandHandlerRequest, Organization>
{
    private IRepository<Organization, string> _organizationRepository;
    private IRepository<User, string> _userRepository;
    private IRepository<TimeArea, string> _timeAreaRepository;
    public OrganizationSaveCommandHandler(IRepository<Organization, string> organizationRepository, IRepository<User, string> userRepository, IRepository<TimeArea, string> timeAreaRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
        _timeAreaRepository = timeAreaRepository;

    }


    public Task<Organization> Handle(OrganizationSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _organizationRepository.AddOneAsync(request.Organization, cancellationToken);
            return request.Organization;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

