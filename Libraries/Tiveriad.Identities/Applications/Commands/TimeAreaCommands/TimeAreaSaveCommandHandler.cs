#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public class TimeAreaSaveCommandHandler : IRequestHandler<TimeAreaSaveCommandHandlerRequest, TimeArea>
{
    private readonly IRepository<TimeArea, string> _timeAreaRepository;

    public TimeAreaSaveCommandHandler(IRepository<TimeArea, string> timeAreaRepository)
    {
        _timeAreaRepository = timeAreaRepository;
    }


    public Task<TimeArea> Handle(TimeAreaSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            await _timeAreaRepository.AddOneAsync(request.TimeArea, cancellationToken);
            return request.TimeArea;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}