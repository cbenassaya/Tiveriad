#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.ClientContracts;
using Tiveriad.Identities.Applications.Queries.ClientQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.ClientEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/{organizationId}/clients")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ClientReaderModel>> HandleAsync(
        [Required] [FromRoute] string organizationId,
        [FromQuery] string? id, [FromQuery] string? name,
        [FromQuery] int? page, [FromQuery] int? limit,
        [FromQuery] string? q, [FromQuery] string[]? orders,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetAllClientsRequest(
                id, organizationId, name, page, limit, q, orders),
            cancellationToken);
        if (result == null || !result.Any())
            return NoContent();
        var data = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientReaderModel>>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}