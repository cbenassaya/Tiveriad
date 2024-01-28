#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;
using Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Documents.Core.Services;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentDescriptionEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IBlobProviderService _blobProviderService;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper, IBlobProviderService blobProviderService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _blobProviderService = blobProviderService;
    }

    [HttpPost("/api/documents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentDescriptionReaderModel>> HandleAsync(
        [FromBody] DocumentDescriptionWriterModel model, CancellationToken cancellationToken)
    {
        using (var memoryStream = new MemoryStream())
        {
            await model.FormFile.CopyToAsync(memoryStream, cancellationToken);
            await _blobProviderService.Get()
                .PutAsync(memoryStream.ToArray(), model.Path, cancellationToken);
        }

        //<-- START CUSTOM CODE-->
        var documentDescription = _mapper.Map<DocumentDescriptionWriterModel, DocumentDescription>(model);
        var result = await _mediator.Send(new SaveDocumentDescriptionRequest(documentDescription), cancellationToken);
        var data = _mapper.Map<DocumentDescription, DocumentDescriptionReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}