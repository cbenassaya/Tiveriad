
using Tiveriad.Notifications.Applications.Commands.SubjectCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Apis.EndPoints.SubjectEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private IMediator _mediator;
    public DeleteEndPoint(IMediator mediator)
    {
        _mediator = mediator;

    }

    [HttpDelete("/api/subjects/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync([FromRoute][Required] string id, CancellationToken cancellationToken)
    {
        
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new SubjectDeleteCommandHandlerRequest(id), cancellationToken);
        return Ok(result);
        
    }
}

