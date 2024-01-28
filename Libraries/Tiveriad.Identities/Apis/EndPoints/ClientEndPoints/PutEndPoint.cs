#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Apis.Filters;
using Tiveriad.Identities.Apis.Contracts.ClientContracts;
using Tiveriad.Identities.Applications.Commands.ClientCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.ClientEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/{organizationId}/clients")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ValidateModel]
    public async Task<ActionResult<ClientReaderModel>> HandleAsync(
        [Required] [FromRoute] string organizationId,
        [FromBody] ClientUpdaterModel model,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var entity = _mapper.Map<ClientUpdaterModel, Client>(model);
        var result = await _mediator.Send(new UpdateClientRequest(entity, organizationId), cancellationToken);
        var data = _mapper.Map<Client, ClientReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}