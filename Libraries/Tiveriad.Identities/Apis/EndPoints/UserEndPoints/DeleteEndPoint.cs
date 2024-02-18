#region

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Applications.Commands.UserCommands;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.UserEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMediator _mediator;

    public DeleteEndPoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("/api/users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync([FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new UserDeleteCommandHandlerRequest(id), cancellationToken);
        return Ok(result);
        //<-- END CUSTOM CODE-->
    }
}