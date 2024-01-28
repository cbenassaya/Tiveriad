#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;
using Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;
using Tiveriad.Documents.Core.Entities;

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

    [HttpPut("/api/documents/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentDescriptionReaderModel>> HandleAsync([FromRoute] string id,
        [FromBody] DocumentDescriptionUpdaterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var documentDescription = _mapper.Map<DocumentDescriptionUpdaterModel, DocumentDescription>(model);
        var result = await _mediator.Send(new UpdateDocumentDescriptionRequest(id, documentDescription),
            cancellationToken);
        var data = _mapper.Map<DocumentDescription, DocumentDescriptionReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}