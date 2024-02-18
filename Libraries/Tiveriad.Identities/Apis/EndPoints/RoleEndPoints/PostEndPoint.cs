#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Applications.Commands.RoleCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/roles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RoleReaderModelContract>> HandleAsync([FromBody] RoleWriterModelContract model,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var role = _mapper.Map<RoleWriterModelContract, Role>(model);
        var result = await _mediator.Send(new RoleSaveCommandHandlerRequest(role), cancellationToken);
        var data = _mapper.Map<Role, RoleReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}