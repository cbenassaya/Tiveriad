#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Applications.Commands.RoleCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ITenantService<string> _tenantService;

    public PostEndPoint(IMediator mediator, IMapper mapper, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tenantService = tenantService;
    }

    [HttpPost("/roles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RoleReaderModelContract>> HandleAsync(
        [FromBody] RoleWriterModelContract model,
        CancellationToken cancellationToken)
    {
        
        var role = _mapper.Map<RoleWriterModelContract, Role>(model);
        var result = await _mediator.Send(new RoleSaveCommandHandlerRequest(_tenantService.GetTenantId(),role), cancellationToken);
        var data = _mapper.Map<Role, RoleReaderModelContract>(result);
        return Ok(data);
        
    }
}