#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentCategoryEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/organizations/{organizationId}/documentCategories/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentCategoryReaderModel>> HandleAsync([FromRoute] string organizationId,
        [FromRoute] string id, [FromBody] DocumentCategoryUpdaterModel model, CancellationToken cancellationToken)
    {
        

        var documentCategory = _mapper.Map<DocumentCategoryUpdaterModel, DocumentCategory>(model);
        var result = await _mediator.Send(new UpdateDocumentCategoryRequest(organizationId, id, documentCategory),
            cancellationToken);
        var data = _mapper.Map<DocumentCategory, DocumentCategoryReaderModel>(result);
        return Ok(data);
        
    }
}