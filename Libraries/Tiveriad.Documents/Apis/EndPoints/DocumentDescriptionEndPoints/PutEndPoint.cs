#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentDescriptionEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/organizations/{organizationId}/documentDescriptions/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentDescriptionReaderModel>> HandleAsync([FromRoute] string organizationId,
        [FromRoute] string id, [FromBody] DocumentDescriptionUpdaterModel model, CancellationToken cancellationToken)
    {
        

        var documentDescription = _mapper.Map<DocumentDescriptionUpdaterModel, DocumentDescription>(model);
        var result = await _mediator.Send(new UpdateDocumentDescriptionRequest(organizationId, id, documentDescription),
            cancellationToken);
        var data = _mapper.Map<DocumentDescription, DocumentDescriptionReaderModel>(result);
        return Ok(data);
        
    }
}