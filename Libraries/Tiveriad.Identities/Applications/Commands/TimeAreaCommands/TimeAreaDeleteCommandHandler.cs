#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public class TimeAreaDeleteCommandHandler : IRequestHandler<TimeAreaDeleteCommandHandlerRequest, bool>
{
    private readonly IRepository<TimeArea, string> _timeAreaRepository;

    public TimeAreaDeleteCommandHandler(IRepository<TimeArea, string> timeAreaRepository)
    {
        _timeAreaRepository = timeAreaRepository;
    }


    public Task<bool> Handle(TimeAreaDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _timeAreaRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);


            var timeArea = query.FirstOrDefault();
            if (timeArea == null) throw new Exception();
            return _timeAreaRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}