#region

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Applications.Commands.FeatureCommands;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.FeatureEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMediator _mediator;

    public DeleteEndPoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("/api/realms/{realmId}/features/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync(
        [FromRoute] [Required] string? realmId,
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new FeatureDeleteCommandHandlerRequest(realmId,id), cancellationToken);
        return Ok(result);
        
    }
}