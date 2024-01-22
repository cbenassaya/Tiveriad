#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Apis.Filters;
using Tiveriad.Identities.Apis.Contracts;
using Tiveriad.Identities.Applications.Commands.ClientCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.ClientEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/{organizationId}/clients")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ValidateModel]
    public async Task<ActionResult<ClientReaderModel>> HandleAsync(
        [Required][FromRoute] string organizationId,
        [FromBody] ClientWriterModel model,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var client = _mapper.Map<ClientWriterModel, Client>(model);
        var result = await _mediator.Send(new SaveClientRequest(client, organizationId), cancellationToken);
        var data = _mapper.Map<Client, ClientReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}