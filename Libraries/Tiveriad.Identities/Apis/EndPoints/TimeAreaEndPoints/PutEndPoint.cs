
using Tiveriad.Identities.Apis.Contracts.TimeAreaContracts;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Applications.Commands.TimeAreaCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.TimeAreaEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/api/timeArea/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TimeAreaReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] TimeAreaWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var timeArea = _mapper.Map<TimeAreaWriterModelContract, TimeArea>(model);
        timeArea.Id = id;
        var result = await _mediator.Send(new TimeAreaUpdateCommandHandlerRequest(timeArea), cancellationToken);
        var data = _mapper.Map<TimeArea, TimeAreaReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

