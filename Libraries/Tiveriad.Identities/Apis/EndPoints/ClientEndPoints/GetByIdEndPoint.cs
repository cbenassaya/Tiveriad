#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.ClientContracts;
using Tiveriad.Identities.Applications.Queries.ClientQueries;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.ClientEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetByIdEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/{organizationId}/clients/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ClientReaderModel>> HandleAsync(
        [Required] [FromRoute] string organizationId,
        [FromRoute] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new GetClientByIdRequest(id, organizationId), cancellationToken);
        if (result == null)
            return NoContent();
        var data = _mapper.Map<Client, ClientReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}