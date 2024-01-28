#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Documents.Apis.Contracts.DocumentDescriptionContracts;
using Tiveriad.Documents.Applications.Queries.DocumentDescriptionQueries;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentDescriptionEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/documents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentDescriptionReaderModel>> HandleAsync([FromRoute] string? id,
        [FromRoute] int? page, [FromRoute] int? limit, [FromRoute] string? q, [FromQuery] IEnumerable<string>? orders,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetAllDocumentDescriptionsRequest(id, page, limit, q, orders),
            cancellationToken);
        if (result == null || !result.Any()) return NoContent();
        var data = _mapper.Map<IEnumerable<DocumentDescription>, IEnumerable<DocumentDescriptionReaderModel>>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}