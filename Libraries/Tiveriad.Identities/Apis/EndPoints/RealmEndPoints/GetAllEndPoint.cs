#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Tiveriad.Identities.Applications.Queries.RealmQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RealmEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/realms")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResult<RealmReaderModelContract>>> HandleAsync([FromQuery] string? id,
        [FromQuery] string? name, [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string? q,
        [FromQuery] IEnumerable<string>? orders, CancellationToken cancellationToken)
    {
        
        var result = await _mediator.Send(new RealmGetAllQueryHandlerRequest(id, name, page, limit, q, orders),
            cancellationToken);
        if (result.Items.Count==0) return NoContent();
        var data = _mapper.Map<PagedResult<Realm>, PagedResult<RealmReaderModelContract>>(result);
        return Ok(data);
        
    }
}