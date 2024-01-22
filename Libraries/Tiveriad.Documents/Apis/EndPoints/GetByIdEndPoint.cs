#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Documents.Apis.Contracts;
using Tiveriad.Documents.Applications.Queries;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints;

public class GetByIdEndPoint<T> : ControllerBase where T : IEquatable<T>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ILogger<GetByIdEndPoint<T>> _logger;
    private readonly IKeyParser<T> _keyParser;


    public GetByIdEndPoint(IMapper mapper, IMediator mediator, ILogger<GetByIdEndPoint<T>> logger, IKeyParser<T> keyParser)
    {
        _mapper = mapper;
        _mediator = mediator;
        _logger = logger;
        _keyParser = keyParser;
    }

    [HttpGet("/api/documentDescriptions/{id}")]
    public async Task<ActionResult<DocumentDescriptionReaderModel>> HandleAsync([FromRoute] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id))
            return BadRequest("Id is mandatory!");
        var result = await _mediator.Send(new GetDocumentDescriptionByIdRequest<T>(_keyParser.Parse(id)), cancellationToken);
        var data = _mapper.Map<DocumentDescriptionBase<T>, DocumentDescriptionReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}