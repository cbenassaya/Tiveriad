#region

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentCategoryEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMediator _mediator;

    public DeleteEndPoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("/api/organizations/{organizationId}/documentCategories/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync([FromRoute] [Required] string organizationId,
        [FromRoute] [Required] string id, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(organizationId)) return BadRequest("OrganizationId is mandatory");
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new DeleteDocumentCategoryByIdRequest(organizationId, id), cancellationToken);
        return Ok(result);
        //<-- END CUSTOM CODE-->
    }
}