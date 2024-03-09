
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Applications.Commands.MembershipCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tiveriad.Core.Abstractions.Services;

namespace Tiveriad.Identities.Apis.EndPoints.MembershipEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ITenantService<string> _tenantService;
    
    public PutEndPoint(IMediator mediator, IMapper mapper, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tenantService = tenantService;
    }

    [HttpPut("/memberships/{id}")]
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


    [HttpPut("/users/{userId}/memberships/default")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<MembershipReaderModelContract>> HandleAsync([FromBody] string userId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DefaultMembershipUpdateCommandHandlerRequest(_tenantService.GetTenantId(), userId),
            cancellationToken);
        var data = _mapper.Map<Membership, MembershipReaderModelContract>(result);
        return Ok(data);
    }

}

