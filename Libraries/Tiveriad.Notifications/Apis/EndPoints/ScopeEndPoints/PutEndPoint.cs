
using Tiveriad.Notifications.Apis.Contracts.ScopeContracts;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Notifications.Applications.Commands.ScopeCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Apis.EndPoints.ScopeEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/api/scopes/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ScopeReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] ScopeWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var scope = _mapper.Map<ScopeWriterModelContract, Scope>(model);
        scope.Id = id;
        var result = await _mediator.Send(new ScopeUpdateCommandHandlerRequest(scope), cancellationToken);
        var data = _mapper.Map<Scope, ScopeReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

