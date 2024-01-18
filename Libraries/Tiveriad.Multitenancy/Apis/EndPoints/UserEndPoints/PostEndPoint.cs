using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Apis.Filters;
using Tiveriad.Multitenancy.Apis.Contracts;
using Tiveriad.Multitenancy.Applications.Commands.UserCommands;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Apis.EndPoints.UserEndPoints;
public class PostEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PostEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/organizations/{organizationId}/users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ValidateModel]
    public async Task<ActionResult<UserReaderModel>> HandleAsync([FromRoute] string organizationId,[FromBody] UserWriterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var entity = _mapper.Map<UserWriterModel, User>(model);
        var result = await _mediator.Send(new SaveUserRequest(ObjectId.Parse(organizationId),entity), cancellationToken);
        var data = _mapper.Map<User, UserReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}