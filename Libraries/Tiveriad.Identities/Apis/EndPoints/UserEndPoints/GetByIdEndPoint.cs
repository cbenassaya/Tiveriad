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

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetByIdEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserReaderModel>> HandleAsync([FromRoute] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetUserByIdRequest(id), cancellationToken);
        if (result == null)
            return NoContent();
        var data = _mapper.Map<User, UserReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}