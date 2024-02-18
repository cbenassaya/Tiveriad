#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Applications.Commands.MembershipCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.MembershipEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/memberships/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MembershipReaderModelContract>> HandleAsync([FromRoute] string id,
        [FromBody] MembershipWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var membership = _mapper.Map<MembershipWriterModelContract, Membership>(model);
        membership.Id = id;
        var result = await _mediator.Send(new MembershipUpdateCommandHandlerRequest(membership), cancellationToken);
        var data = _mapper.Map<Membership, MembershipReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}