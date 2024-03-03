#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentDescriptionEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/organizations/{organizationId}/documentDescriptions/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentDescriptionReaderModel>> HandleAsync(
        [FromRoute] [Required] string organizationId, [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        
        if (string.IsNullOrEmpty(organizationId)) return BadRequest("OrganizationId is mandatory");
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new GetDocumentDescriptionByIdRequest(organizationId, id), cancellationToken);
        if (result == null) return NoContent();
        var data = _mapper.Map<DocumentDescription, DocumentDescriptionReaderModel>(result);
        return Ok(data);
        
    }
}