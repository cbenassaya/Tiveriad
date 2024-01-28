#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Documents.Apis.Contracts.DocumentCategoryContracts;
using Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;
using Tiveriad.Documents.Core.Entities;

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

    [HttpPost("/api/documentcategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentCategoryReaderModel>> HandleAsync(
        [FromBody] DocumentCategoryWriterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var documentCategory = _mapper.Map<DocumentCategoryWriterModel, DocumentCategory>(model);
        var result = await _mediator.Send(new SaveDocumentCategoryRequest(documentCategory), cancellationToken);
        var data = _mapper.Map<DocumentCategory, DocumentCategoryReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}