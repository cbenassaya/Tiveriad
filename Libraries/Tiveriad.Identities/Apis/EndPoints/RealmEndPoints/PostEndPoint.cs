#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Tiveriad.Identities.Applications.Commands.RealmCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.RealmEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/realms")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RealmReaderModelContract>> HandleAsync([FromBody] RealmWriterModelContract model,
        CancellationToken cancellationToken)
    {
        
        var realm = _mapper.Map<RealmWriterModelContract, Realm>(model);
        var result = await _mediator.Send(new RealmSaveCommandHandlerRequest(realm), cancellationToken);
        var data = _mapper.Map<Realm, RealmReaderModelContract>(result);
        return Ok(data);
        
    }
}