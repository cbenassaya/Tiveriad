
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public class TimeAreaUpdateCommandHandler : IRequestHandler<TimeAreaUpdateCommandHandlerRequest, TimeArea>
{
    private IRepository<TimeArea, string> _timeAreaRepository;
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

