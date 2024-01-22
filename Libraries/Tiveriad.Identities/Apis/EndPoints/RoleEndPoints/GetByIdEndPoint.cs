#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Applications.Queries.RoleQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RoleEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetByIdEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/{organizationId}/clients/{clientId}/roles/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RoleReaderModel>> HandleAsync(        
        [FromQuery] string id,
        [FromRoute] string clientId,
        [FromRoute] string organizationId,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetRoleByIdRequest( id, organizationId,clientId), cancellationToken);
        if (result == null)
            return NoContent();
        var data = _mapper.Map<Role, RoleReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}