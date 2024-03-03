#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.FeatureContracts;
using Tiveriad.Identities.Applications.Queries.FeatureQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.FeatureEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/realms/{realmId}/features/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FeatureReaderModelContract>> HandleAsync(
        [FromRoute] [Required] string? realmId,
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        
        var result = await _mediator.Send(new FeatureGetByIdQueryHandlerRequest(realmId, id), cancellationToken);
        if (result == null) return NoContent();
        var data = _mapper.Map<Feature, FeatureReaderModelContract>(result);
        return Ok(data);
        
    }
}