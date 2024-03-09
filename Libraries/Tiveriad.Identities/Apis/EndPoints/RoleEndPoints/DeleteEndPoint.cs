#region

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Applications.Commands.RoleCommands;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class DeleteEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITenantService<string> _tenantService;

    public DeleteEndPoint(IMediator mediator, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _tenantService = tenantService;
    }

    [HttpDelete("/roles/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync(
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new RoleDeleteCommandHandlerRequest(_tenantService.GetTenantId(),id), cancellationToken);
        return Ok(result);
        
    }
}