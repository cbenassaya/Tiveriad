
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
    public OrganizationSaveCommandHandler(IRepository<Organization, string> organizationRepository, IRepository<User, string> userRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;

    }


    public Task<Organization> Handle(OrganizationSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            if (request.Organization.Owner != null) request.Organization.Owner = await _userRepository.GetByIdAsync(request.Organization.Owner.Id, cancellationToken);
            request.Organization.State = OrganizationState.Pending;
            await _organizationRepository.AddOneAsync(request.Organization, cancellationToken);
            return request.Organization;
        }, cancellationToken);
    }
}

