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

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ITenantService<string> _tenantService;

    public GetByIdEndPoint(IMediator mediator, IMapper mapper, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tenantService = tenantService;
    }

    [HttpGet("/roles/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RoleReaderModelContract>> HandleAsync(
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        
        var result = await _mediator.Send(new RoleGetByIdQueryHandlerRequest(_tenantService.GetTenantId(),id), cancellationToken);
        if (result == null) return NoContent();
        var data = _mapper.Map<Role, RoleReaderModelContract>(result);
        return Ok(data);
        
    }
}