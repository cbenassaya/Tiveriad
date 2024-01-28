#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Applications.Queries.OrganizationQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.OrganizationEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/organizations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrganizationReaderModel>> HandleAsync(
        [FromQuery] string? id, [FromQuery] string? name,
        [FromQuery] int? page, [FromQuery] int? limit,
        [FromQuery] string? q, [FromQuery] string[]? orders,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetAllOrganizationsRequest(id, name, page, limit, q, orders),
            cancellationToken);
        if (result == null || !result.Any())
            return NoContent();
        var data = _mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationReaderModel>>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}