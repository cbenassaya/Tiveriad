#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.PolicyContracts;
using Tiveriad.Identities.Applications.Queries.PolicyQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.PolicyEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/realms/{realmId}/roles/{roleId}/policies/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PolicyReaderModelContract>> HandleAsync(
        [FromRoute] string realmId,[FromRoute] string roleId,
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new PolicyGetByIdQueryHandlerRequest(realmId,roleId,id), cancellationToken);
        if (result == null) return NoContent();
        var data = _mapper.Map<Policy, PolicyReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}