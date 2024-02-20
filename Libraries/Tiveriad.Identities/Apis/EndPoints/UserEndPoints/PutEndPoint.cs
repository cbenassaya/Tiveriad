#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.UserEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserReaderModelContract>> HandleAsync([FromRoute] string id,
        [FromBody] UserWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var user = _mapper.Map<UserWriterModelContract, User>(model);
        user.Id = id;
        var result = await _mediator.Send(new UserUpdateCommandHandlerRequest(id,user), cancellationToken);
        var data = _mapper.Map<User, UserReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}