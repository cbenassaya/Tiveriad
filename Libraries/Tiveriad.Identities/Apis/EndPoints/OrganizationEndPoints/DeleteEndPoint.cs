
using Tiveriad.Identities.Applications.Commands.OrganizationCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.OrganizationEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private IMediator _mediator;
    public DeleteEndPoint(IMediator mediator)
    {
        _mediator = mediator;

    }

    [HttpDelete("/api/organizations/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync([FromRoute][Required] string id, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new OrganizationDeleteCommandHandlerRequest(id), cancellationToken);
        return Ok(result);
        //<-- END CUSTOM CODE-->
    }
}

