
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

    [HttpGet("/api/organizations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<OrganizationReaderModelContract>>> HandleAsync([FromQuery] string? id, [FromQuery] string? name, [FromQuery] string? domain, [FromQuery] OrganizationState? state, [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string? q, [FromQuery] IEnumerable<string>? orders, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new OrganizationGetAllQueryHandlerRequest(id, name, domain, state, page, limit, q, orders), cancellationToken);
        if (!result.Any()) return NoContent(); var data = _mapper.Map<List<Organization>, List<OrganizationReaderModelContract>>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

