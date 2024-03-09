
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Applications.Queries.OrganizationQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.OrganizationEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet("/organizations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResult<OrganizationReaderModelContract>>> HandleAsync([FromQuery] string? id = null, [FromQuery] string? name = null, [FromQuery] string? domain = null, [FromQuery] OrganizationState? state = null, [FromQuery] string? userId = null, [FromQuery] int? page = null, [FromQuery] int? limit = null, [FromQuery] string? q = null, [FromQuery] List<string>? orders = null, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new OrganizationGetAllQueryHandlerRequest(id, name, domain, state, userId, page, limit, q, orders), cancellationToken);
        if (result.Items.Count==0) return NoContent();
        var data = _mapper.Map<PagedResult<Organization>, PagedResult<OrganizationReaderModelContract>>(result);
        return Ok(data);
    }
}

