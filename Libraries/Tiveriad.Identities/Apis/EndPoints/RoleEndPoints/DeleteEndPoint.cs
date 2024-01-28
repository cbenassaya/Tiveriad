#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Applications.Commands.RoleCommands;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public DeleteEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpDelete("/api/{organizationId}/clients/{clientId}/roles/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync(
        [FromRoute] [Required] string organizationId,
        [FromRoute] [Required] string clientId,
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new DeleteRoleByIdRequest(
            organizationId, clientId, id
        ), cancellationToken);
        //<-- END CUSTOM CODE-->
        return Ok(result);
    }
}