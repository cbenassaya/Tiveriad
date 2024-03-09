#region

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Applications.Commands.PolicyCommands;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.PolicyEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMediator _mediator;

    public DeleteEndPoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("/realms/{realmId}/roles/{roleId}/policies/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync(
        [FromRoute] string realmId,[FromRoute] string roleId,
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new PolicyDeleteCommandHandlerRequest(realmId,roleId,id), cancellationToken);
        return Ok(result);
        
    }
}