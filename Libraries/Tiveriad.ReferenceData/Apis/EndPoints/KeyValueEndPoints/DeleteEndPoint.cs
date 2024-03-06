
using Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.ReferenceData.Core.Entities;

namespace Tiveriad.ReferenceData.Apis.EndPoints.KeyValueEndPoints;

public class DeleteEndPoint<TKeyValue> : ControllerBase
    where TKeyValue : KeyValue
{
    private readonly IMediator _mediator;
    private readonly ITenantService<string> _tenantService;
    public DeleteEndPoint(IMediator mediator, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _tenantService = tenantService;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync([FromRoute][Required] string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new KeyValueDeleteCommandHandlerRequest(_tenantService.GetTenantId(), id), cancellationToken);
        return Ok(result);
    }
}

