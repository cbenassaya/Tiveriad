using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Multitenancy.Apis.Contracts;
using Tiveriad.Multitenancy.Applications.Queries.UserQueries;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Apis.EndPoints.UserEndPoints;
public class GetByIdEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
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
    public async Task<ActionResult<UserReaderModel>> HandleAsync([FromRoute] string id, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetUserByIdRequest(ObjectId.Parse(id)), cancellationToken);
        if (result == null)
            return NoContent();
        var data = _mapper.Map<User, UserReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}