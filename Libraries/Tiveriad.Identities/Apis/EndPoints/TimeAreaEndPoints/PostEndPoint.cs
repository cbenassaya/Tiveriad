#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.TimeAreaContracts;
using Tiveriad.Identities.Applications.Commands.TimeAreaCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.TimeAreaEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/timeAreas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TimeAreaReaderModelContract>> HandleAsync(
        [FromBody] TimeAreaWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var timeArea = _mapper.Map<TimeAreaWriterModelContract, TimeArea>(model);
        var result = await _mediator.Send(new TimeAreaSaveCommandHandlerRequest(timeArea), cancellationToken);
        var data = _mapper.Map<TimeArea, TimeAreaReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}