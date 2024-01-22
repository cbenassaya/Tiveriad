#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Documents.Apis.Contracts;
using Tiveriad.Documents.Applications.Commands;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints;

public class PutEndPoint<T> : ControllerBase where T : IEquatable<T>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/documentDescriptions")]
    public async Task<ActionResult<DocumentDescriptionReaderModel>> HandleAsync(
        [FromBody] DocumentDescriptionUpdaterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var documentDescription = _mapper.Map<DocumentDescriptionUpdaterModel, DocumentDescriptionBase<T>>(model);
        var data = await _mediator.Send(new UpdateDocumentDescriptionRequest<T>(documentDescription),
            cancellationToken);
        return _mapper.Map<DocumentDescriptionBase<T>, DocumentDescriptionReaderModel>(data);
        //<-- END CUSTOM CODE-->
    }
}