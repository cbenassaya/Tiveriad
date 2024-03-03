
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Applications.Commands.MembershipCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.MembershipEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/api/memberships/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MembershipReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] MembershipWriterModelContract model, CancellationToken cancellationToken)
    {

        var membership = _mapper.Map<MembershipWriterModelContract, Membership>(model);
        var result = await _mediator.Send(new MembershipUpdateCommandHandlerRequest(id, membership), cancellationToken);
        var data = _mapper.Map<Membership, MembershipReaderModelContract>(result);
        return Ok(data);
    }
}

