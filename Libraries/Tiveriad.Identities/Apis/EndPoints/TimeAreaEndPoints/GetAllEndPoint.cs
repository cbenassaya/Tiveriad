#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.TimeAreaContracts;
using Tiveriad.Identities.Applications.Queries.TimeAreaQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.TimeAreaEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/timeAreas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<TimeAreaReaderModelContract>>> HandleAsync([FromQuery] string? id,
        [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string? q, [FromQuery] IEnumerable<string>? orders,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new TimeAreaGetAllQueryHandlerRequest(id, page, limit, q, orders),
            cancellationToken);
        if (!result.Any()) return NoContent();
        var data = _mapper.Map<List<TimeArea>, List<TimeAreaReaderModelContract>>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}