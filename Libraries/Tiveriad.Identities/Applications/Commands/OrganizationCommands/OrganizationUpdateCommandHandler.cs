#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Core.StateMachines;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public class OrganizationUpdateCommandHandler : IRequestHandler<OrganizationUpdateCommandHandlerRequest, Organization>
{
    private readonly IRepository<Organization, string> _organizationRepository;
    private readonly IRepository<TimeArea, string> _timeAreaRepository;
    private readonly IRepository<User, string> _userRepository;

    public OrganizationUpdateCommandHandler(IRepository<Organization, string> organizationRepository,
        IRepository<User, string> userRepository, IRepository<TimeArea, string> timeAreaRepository)
    {
        _organizationRepository = organizationRepository;
        _userRepository = userRepository;
        _timeAreaRepository = timeAreaRepository;
    }


    public Task<Organization> Handle(OrganizationUpdateCommandHandlerRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _organizationRepository.Queryable.Include(x => x.Owner)
                .Include(x => x.TimeArea).AsQueryable();

            query = query.Where(x => x.Id == request.Organization.Id);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();
            result.Name = request.Organization.Name;
            result.Domain = request.Organization.Domain;
            result.Description = request.Organization.Description;
            result.Properties = request.Organization.Properties;
            if (request.Organization.TimeArea != null)
                result.TimeArea =
                    await _timeAreaRepository.GetByIdAsync(request.Organization.TimeArea.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}


public class OrganizationStateUpdateCommandHandler : IRequestHandler<OrganizationStateUpdateCommandHandlerRequest, Organization>
{
    private readonly IRepository<Organization, string> _organizationRepository;

    public OrganizationStateUpdateCommandHandler(IRepository<Organization, string> organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }


    public Task<Organization> Handle(OrganizationStateUpdateCommandHandlerRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _organizationRepository.Queryable.AsQueryable();
            query = query.Where(x => x.Id == request.Id);
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();
            var sm = result.State.GetStateMachine();
            sm.Fire(request.Event);
            result.State = sm.GetCurrentState();
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}