#region

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Applications.Commands.RoleCommands;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMediator _mediator;

    public DeleteEndPoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("/api/organizations/{organizationId}/roles/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync(
        [FromRoute] [Required] string organizationId,
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new RoleDeleteCommandHandlerRequest(organizationId,id), cancellationToken);
        return Ok(result);
        //<-- END CUSTOM CODE-->
    }
}