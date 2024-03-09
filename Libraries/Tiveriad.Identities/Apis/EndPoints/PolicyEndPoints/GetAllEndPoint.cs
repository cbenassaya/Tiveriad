#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.PolicyContracts;
using Tiveriad.Identities.Applications.Queries.PolicyQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.PolicyEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/realms/{realmId}/roles/{roleId}/policies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResult<PolicyReaderModelContract>>> HandleAsync(
        [FromRoute] string realmId,[FromRoute] string roleId,
        [FromQuery] string? id,
        [FromQuery] string? name, [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string? q,
        [FromQuery] IEnumerable<string>? orders, CancellationToken cancellationToken)
    {
        
        var result = await _mediator.Send(new PolicyGetAllQueryHandlerRequest(realmId, roleId, id, name, page, limit, q, orders),
            cancellationToken);
        if (result.Items.Count==0) return NoContent();
        var data = _mapper.Map<PagedResult<Policy>, PagedResult<PolicyReaderModelContract>>(result);
        return Ok(data);
        
    }
}