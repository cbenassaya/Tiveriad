#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentCategoryEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/organizations/{organizationId}/documentCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentCategoryReaderModel>> HandleAsync([FromRoute] string organizationId,
        [FromBody] DocumentCategoryWriterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var documentCategory = _mapper.Map<DocumentCategoryWriterModel, DocumentCategory>(model);
        documentCategory.OrganizationId = organizationId;
        var result = await _mediator.Send(new SaveDocumentCategoryRequest(organizationId, documentCategory),
            cancellationToken);
        var data = _mapper.Map<DocumentCategory, DocumentCategoryReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}