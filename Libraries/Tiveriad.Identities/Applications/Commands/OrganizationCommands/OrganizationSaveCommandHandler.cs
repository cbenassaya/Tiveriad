#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationSaveCommandHandler : IRequestHandler<OrganizationSaveCommandHandlerRequest, Organization>
{
    private readonly IRepository<Organization, string> _organizationRepository;
    private IRepository<TimeArea, string> _timeAreaRepository;
    private IRepository<User, string> _userRepository;

    public OrganizationSaveCommandHandler(IRepository<Organization, string> organizationRepository,
        IRepository<User, string> userRepository, IRepository<TimeArea, string> timeAreaRepository)
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
            request.Organization.State = OrganizationState.Pending;
            if (request.Organization.Owner != null)
                request.Organization.Owner = await _userRepository.GetByIdAsync(request.Organization.Owner.Id, cancellationToken);
            if (request.Organization.TimeArea != null)
                request.Organization.TimeArea =
                    await _timeAreaRepository.GetByIdAsync(request.Organization.TimeArea.Id, cancellationToken);
            await _organizationRepository.AddOneAsync(request.Organization, cancellationToken);
            return request.Organization;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}