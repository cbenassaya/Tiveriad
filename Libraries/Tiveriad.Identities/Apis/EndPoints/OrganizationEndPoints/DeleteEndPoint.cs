#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Applications.Commands.OrganizationCommands;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.OrganizationEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public DeleteEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpDelete("/api/organizations/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync([FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id))
            return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new DeleteOrganizationByIdRequest(id), cancellationToken);
        //<-- END CUSTOM CODE-->
        return Ok(result);
    }
}