#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Applications.Queries.RoleQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/organizations/{organizationId}/roles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<RoleReaderModelContract>>> HandleAsync(
        [FromRoute] [Required] string organizationId,
        [FromQuery] string? id,
        [FromQuery] string? name, [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string? q,
        [FromQuery] IEnumerable<string>? orders, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new RoleGetAllQueryHandlerRequest(organizationId,id, name, page, limit, q, orders),
            cancellationToken);
        if (!result.Any()) return NoContent();
        var data = _mapper.Map<List<Role>, List<RoleReaderModelContract>>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}