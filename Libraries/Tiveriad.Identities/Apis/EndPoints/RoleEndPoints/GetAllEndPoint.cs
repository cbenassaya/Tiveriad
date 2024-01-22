#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Applications.Queries.RoleQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/{organizationId}/clients/{clientId}/roles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RoleReaderModel>> HandleAsync(
        [FromQuery] string? id,
        [FromRoute] string clientId,
        [FromRoute] string organizationId,
        [FromQuery] string? name,
        [FromQuery] int? page, [FromQuery] int? limit,
        [FromQuery] string? q, [FromQuery] string[]? orders,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetAllRolesRequest(
                id, organizationId,clientId,name, page, limit, q, orders),
            cancellationToken);
        if (result == null || !result.Any())
            return NoContent();
        var data = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleReaderModel>>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}