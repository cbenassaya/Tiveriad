#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Apis.Filters;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Applications.Commands.UserCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.UserEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/organizations/{organizationId}/clients/{clientId}/users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ValidateModel]
    public async Task<ActionResult<UserReaderModel>> HandleAsync([FromRoute] string organizationId,
        [FromRoute] string clientId,
        [FromBody] UserWriterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var entity = _mapper.Map<UserWriterModel, User>(model);
        var result = await _mediator.Send(new SaveUserRequest(organizationId, clientId, entity), cancellationToken);
        var data = _mapper.Map<User, UserReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}