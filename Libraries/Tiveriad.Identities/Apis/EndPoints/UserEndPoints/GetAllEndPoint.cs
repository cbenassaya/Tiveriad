#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Applications.Queries.UserQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.UserEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/organizations/users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserReaderModel>> HandleAsync(
        [FromQuery] string? id,
        [FromQuery] string? email, [FromQuery] string? username,
        [FromQuery] string? firstname, [FromQuery] string? lastname,
        [FromQuery] string[]? states,
        [FromQuery] int? page, [FromQuery] int? limit,
        [FromQuery] string? q, [FromQuery] string[]? orders,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetAllUsersRequest(
            id,
            email,
            username,
            firstname,
            lastname,
            states,
            page,
            limit,
            q,
            orders
        ), cancellationToken);
        if (result == null || !result.Any())
            return NoContent();
        var data = _mapper.Map<IEnumerable<User>, IEnumerable<UserReaderModel>>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}