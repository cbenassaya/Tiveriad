#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Documents.Core.Services;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentDescriptionEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IBlobServiceProvider _blobServiceProvider;

    public PostEndPoint(IMediator mediator, IMapper mapper, IBlobServiceProvider blobServiceProvider)
    {
        _mediator = mediator;
        _mapper = mapper;
        _blobServiceProvider = blobServiceProvider;
    }

    [HttpPost("/api/organizations/{organizationId}/documentDescriptions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentDescriptionReaderModel>> HandleAsync([FromRoute] string organizationId,
        [FromForm] DocumentDescriptionWriterModel model, CancellationToken cancellationToken)
    {
        
        var documentDescription = _mapper.Map<DocumentDescriptionWriterModel, DocumentDescription>(model);
        documentDescription.OrganizationId = organizationId;
        documentDescription.Provider = _blobServiceProvider.Get().Name;
        var result = await _mediator.Send(new SaveDocumentDescriptionRequest(organizationId, documentDescription),
            cancellationToken);
        var data = _mapper.Map<DocumentDescription, DocumentDescriptionReaderModel>(result);
        
        using (var memoryStream = new MemoryStream())
        {
            await model.FormFile.CopyToAsync(memoryStream,cancellationToken);
            await _blobServiceProvider.Get().PutAsync(memoryStream.ToArray(),model.Path, model.Name,cancellationToken);
        }
        
        return Ok(data);
        
    }
}