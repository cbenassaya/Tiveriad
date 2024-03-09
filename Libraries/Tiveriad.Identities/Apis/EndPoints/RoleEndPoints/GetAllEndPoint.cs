#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Applications.Queries.RoleQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ITenantService<string> _tenantService;

    public GetAllEndPoint(IMediator mediator, IMapper mapper, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tenantService = tenantService;
    }

    [HttpGet("/roles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResult<RoleReaderModelContract>>> HandleAsync(
        [FromQuery] string? id,
        [FromQuery] string? name, [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string? q,
        [FromQuery] IEnumerable<string>? orders, CancellationToken cancellationToken)
    {
        
        var result = await _mediator.Send(new RoleGetAllQueryHandlerRequest(_tenantService.GetTenantId(),id, name, page, limit, q, orders),
            cancellationToken);
        if (result.Items.Count==0) return NoContent();
        var data = _mapper.Map<PagedResult<Role>, PagedResult<RoleReaderModelContract>>(result);
        return Ok(data);
        
    }
}