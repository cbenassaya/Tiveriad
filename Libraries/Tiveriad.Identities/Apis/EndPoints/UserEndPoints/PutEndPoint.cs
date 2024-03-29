
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.UserEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] UserWriterModelContract model, CancellationToken cancellationToken)
    {

        var user = _mapper.Map<UserWriterModelContract, User>(model);
        var result = await _mediator.Send(new UserUpdateCommandHandlerRequest(id, user), cancellationToken);
        var data = _mapper.Map<User, UserReaderModelContract>(result);
        return Ok(data);
    }
}

