#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Apis.Filters;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Applications.Commands.RoleCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/{organizationId}/clients/{clientId}/roles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ValidateModel]
    public async Task<ActionResult<RoleReaderModel>> HandleAsync(
        [FromRoute] string organizationId,
        [FromRoute] string clientId,
        [FromBody] RoleWriterModel model,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var role = _mapper.Map<RoleWriterModel, Role>(model);
        var result = await _mediator.Send(new SaveRoleRequest(
            organizationId, clientId,
            role), cancellationToken);
        var data = _mapper.Map<Role, RoleReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}