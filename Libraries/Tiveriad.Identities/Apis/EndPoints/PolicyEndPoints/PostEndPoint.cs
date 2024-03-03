#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.PolicyContracts;
using Tiveriad.Identities.Applications.Commands.PolicyCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.PolicyEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/realms/{realmId}/roles/{roleId}/policies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PolicyReaderModelContract>> HandleAsync(
        [FromRoute] string realmId,[FromRoute] string roleId,
        [FromBody] PolicyWriterModelContract model,
        CancellationToken cancellationToken)
    {
        
        var policy = _mapper.Map<PolicyWriterModelContract, Policy>(model);
        var result = await _mediator.Send(new PolicySaveCommandHandlerRequest(realmId,roleId,policy), cancellationToken);
        var data = _mapper.Map<Policy, PolicyReaderModelContract>(result);
        return Ok(data);
        
    }
}