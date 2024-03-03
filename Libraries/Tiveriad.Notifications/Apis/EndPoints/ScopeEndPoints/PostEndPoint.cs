
using Tiveriad.Notifications.Apis.Contracts.ScopeContracts;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Notifications.Applications.Commands.ScopeCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Apis.EndPoints.ScopeEndPoints;

public class PostEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPost("/api/scopes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ScopeReaderModelContract>> HandleAsync([FromBody] ScopeWriterModelContract model, CancellationToken cancellationToken)
    {
        
        var scope = _mapper.Map<ScopeWriterModelContract, Scope>(model);
        var result = await _mediator.Send(new ScopeSaveCommandHandlerRequest(scope), cancellationToken);
        var data = _mapper.Map<Scope, ScopeReaderModelContract>(result);
        return Ok(data);
        
    }
}

