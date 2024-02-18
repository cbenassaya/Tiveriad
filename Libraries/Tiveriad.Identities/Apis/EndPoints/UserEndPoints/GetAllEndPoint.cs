#region

using AutoMapper;
using MediatR;
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

    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<UserReaderModelContract>>> HandleAsync([FromQuery] string? id,
        [FromQuery] string? firstname, [FromQuery] string? lastname, [FromQuery] string? username,
        [FromQuery] string? password, [FromQuery] string? email, [FromQuery] int? page, [FromQuery] int? limit,
        [FromQuery] string? q, [FromQuery] IEnumerable<string>? orders, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result =
            await _mediator.Send(
                new UserGetAllQueryHandlerRequest(id, firstname, lastname, username, password, email, page, limit, q,
                    orders), cancellationToken);
        if (!result.Any()) return NoContent();
        var data = _mapper.Map<List<User>, List<UserReaderModelContract>>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}