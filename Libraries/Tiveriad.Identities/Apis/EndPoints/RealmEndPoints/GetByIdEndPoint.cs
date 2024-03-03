#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Tiveriad.Identities.Applications.Queries.RealmQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RealmEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/realms/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RealmReaderModelContract>> HandleAsync([FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        
        var result = await _mediator.Send(new RealmGetByIdQueryHandlerRequest(id), cancellationToken);
        if (result == null) return NoContent();
        var data = _mapper.Map<Realm, RealmReaderModelContract>(result);
        return Ok(data);
        
    }
}