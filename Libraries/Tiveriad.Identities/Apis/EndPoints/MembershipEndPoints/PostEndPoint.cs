
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Applications.Commands.MembershipCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.MembershipEndPoints;

public class PostEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPost("/api/memberships")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MembershipReaderModelContract>> HandleAsync([FromBody] MembershipWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var membership = _mapper.Map<MembershipWriterModelContract, Membership>(model);
        var result = await _mediator.Send(new MembershipSaveCommandHandlerRequest(membership), cancellationToken);
        var data = _mapper.Map<Membership, MembershipReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

