#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Applications.Commands.ClientCommands;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.ClientEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public DeleteEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpDelete("/api/{organizationId}/clients/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync(
        [Required][FromRoute] string organizationId,
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id))
            return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new DeleteClientByIdRequest(id,organizationId), cancellationToken);
        //<-- END CUSTOM CODE-->
        return Ok(result);
    }
}