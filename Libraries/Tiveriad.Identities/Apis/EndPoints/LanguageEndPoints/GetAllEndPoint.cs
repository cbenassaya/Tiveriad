
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Apis.Contracts.LanguageContracts;
using Tiveriad.Identities.Applications.Queries.LanguageQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.LanguageEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet("/api/languages")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<LanguageReaderModelContract>>> HandleAsync([FromQuery] string? id, [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string? q, [FromQuery] IEnumerable<string>? orders, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new LanguageGetAllQueryHandlerRequest(id, page, limit, q, orders), cancellationToken);
        if (!result.Any()) return NoContent(); var data = _mapper.Map<List<Language>, List<LanguageReaderModelContract>>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

