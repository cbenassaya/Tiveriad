#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public class TimeAreaUpdateCommandHandler : IRequestHandler<TimeAreaUpdateCommandHandlerRequest, TimeArea>
{
    private readonly IRepository<TimeArea, string> _timeAreaRepository;

    public TimeAreaUpdateCommandHandler(IRepository<TimeArea, string> timeAreaRepository)
    {
        _timeAreaRepository = timeAreaRepository;
    }


    public Task<TimeArea> Handle(TimeAreaUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _timeAreaRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);


            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.TimeArea.Name;
            result.Code = request.TimeArea.Code;
            result.Descriptions = request.TimeArea.Descriptions;

            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}