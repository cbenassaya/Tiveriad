#region

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentDescriptionEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMediator _mediator;

    public DeleteEndPoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("/api/documents/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync([FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new DeleteDocumentDescriptionByIdRequest(id), cancellationToken);
        return Ok(result);
        //<-- END CUSTOM CODE-->
    }
}