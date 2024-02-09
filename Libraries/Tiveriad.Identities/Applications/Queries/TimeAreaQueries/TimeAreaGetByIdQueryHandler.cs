
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.TimeAreaQueries;

public class TimeAreaGetByIdQueryHandler : IRequestHandler<TimeAreaGetByIdQueryHandlerRequest, TimeArea?>
{
    private IRepository<TimeArea, string> _timeAreaRepository;
    public TimeAreaGetByIdQueryHandler(IRepository<TimeArea, string> timeAreaRepository)
    {
        _timeAreaRepository = timeAreaRepository;

    }


    public Task<TimeArea?> Handle(TimeAreaGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _timeAreaRepository.Queryable;
        query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

