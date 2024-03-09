
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
using Tiveriad.Core.Abstractions.Services;

namespace Tiveriad.Identities.Apis.EndPoints.MembershipEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ITenantService<string> _tenantService;
    public GetAllEndPoint(IMediator mediator, IMapper mapper, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tenantService = tenantService;
    }

    [HttpGet("/memberships")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResult<MembershipReaderModelContract>>> HandleAsync([FromQuery] string? id = null, [FromQuery] string? userId = null, [FromQuery] int? page = null, [FromQuery] int? limit = null, [FromQuery] string? q = null, [FromQuery] List<string>? orders = null, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new MembershipGetAllQueryHandlerRequest(id, userId, _tenantService.GetTenantId(), page, limit, q, orders), cancellationToken);
        if (result.Items.Count==0) return NoContent();
        var data = _mapper.Map<PagedResult<Membership>, PagedResult<MembershipReaderModelContract>>(result);
        return Ok(data);
    }
}

