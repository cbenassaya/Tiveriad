using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Multitenancy.Apis.Contracts;
using Tiveriad.Multitenancy.Applications.Queries.UserQueries;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Apis.EndPoints.UserEndPoints;
public class GetAllEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public GetAllEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/organizations/{organizationId}/users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserReaderModel>> HandleAsync(
        [FromRoute] string organizationId,
        [FromQuery] string? id,
        [FromQuery] string? email, [FromQuery]  string? username,
        [FromQuery] string? firstname,  [FromQuery] string? lastname, 
        [FromQuery] string[]? states,
        [FromQuery] int? page, [FromQuery] int? limit,
        [FromQuery] string? q, [FromQuery] string[]? orders,
        CancellationToken cancellationToken)
    {
        
        ObjectId? oranizationId = string.IsNullOrEmpty(organizationId) ? null : ObjectId.Parse(organizationId);
        ObjectId? userId = string.IsNullOrEmpty(id) ? null : ObjectId.Parse(id);
        
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetAllUsersRequest(
            oranizationId,
            userId,
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