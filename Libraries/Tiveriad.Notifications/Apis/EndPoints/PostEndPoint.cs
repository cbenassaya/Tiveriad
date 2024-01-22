#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Documents.Apis.Contracts;
using Tiveriad.Documents.Applications.Commands;
using Tiveriad.Documents.Core.Services;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints;

public class PostEndPoint<T> : ControllerBase where T : IEquatable<T>
{
    private readonly IBlobProviderService _blobProviderService;
    private readonly ILogger<PostEndPoint<T>> _logger;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;


    public PostEndPoint(ILogger<PostEndPoint<T>> logger, IBlobProviderService blobProviderService, IMediator mediator,
        IMapper mapper)
    {
        _logger = logger;
        _blobProviderService = blobProviderService;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("api/documents")]
    public async Task<ActionResult<DocumentDescriptionReaderModel>> HandleAsync(
        [FromForm] DocumentDescriptionWriterModel descriptionWriterModel, CancellationToken cancellationToken = default)
    {
        using (var memoryStream = new MemoryStream())
        {
            await descriptionWriterModel.FormFile.CopyToAsync(memoryStream, cancellationToken);
            await _blobProviderService.Get()
                .PutAsync(memoryStream.ToArray(), descriptionWriterModel.Path, cancellationToken);
        }

        var documentDescription =
            _mapper.Map<DocumentDescriptionWriterModel, DocumentDescriptionBase<T>>(descriptionWriterModel);
        var data = await _mediator.Send(new SaveDocumentDescriptionRequest<T>(documentDescription), cancellationToken);
        var result = _mapper.Map<DocumentDescriptionBase<T>, DocumentDescriptionReaderModel>(data);
        return Ok(result);
    }
}