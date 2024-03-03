#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationSaveCommandHandler : IRequestHandler<OrganizationSaveCommandHandlerRequest, Organization>
{
    private readonly IRepository<Organization, string> _organizationRepository;
    private IRepository<User, string> _userRepository;

    public OrganizationSaveCommandHandler(IRepository<Organization, string> organizationRepository,
        IRepository<User, string> userRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
    }


    public Task<Organization> Handle(OrganizationSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            request.Organization.State = OrganizationState.Pending;
            await _organizationRepository.AddOneAsync(request.Organization, cancellationToken);
            return request.Organization;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}