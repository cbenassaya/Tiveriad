#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.PolicyContracts;
using Tiveriad.Identities.Applications.Commands.PolicyCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.PolicyEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/realms/{realmId}/roles/{roleId}/policies/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PolicyReaderModelContract>> HandleAsync(
        [FromRoute] string realmId,[FromRoute] string roleId,
        [FromRoute] string id,
        [FromBody] PolicyWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var policy = _mapper.Map<PolicyWriterModelContract, Policy>(model);
        var result = await _mediator.Send(new PolicyUpdateCommandHandlerRequest(realmId, roleId, id , policy), cancellationToken);
        var data = _mapper.Map<Policy, PolicyReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}