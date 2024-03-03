
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Applications.Queries.MembershipQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.MembershipEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet("/api/memberships")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<MembershipReaderModelContract>>> HandleAsync([FromQuery] string? id = null, [FromQuery] string? userId = null, [FromQuery] string? organizationId = null, [FromQuery] int? page = null, [FromQuery] int? limit = null, [FromQuery] string? q = null, [FromQuery] List<string>? orders = null, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new MembershipGetAllQueryHandlerRequest(id, userId, organizationId, page, limit, q, orders), cancellationToken);
        if (!result.Any()) return NoContent(); var data = _mapper.Map<List<Membership>, List<MembershipReaderModelContract>>(result);
        return Ok(data);
    }
}

