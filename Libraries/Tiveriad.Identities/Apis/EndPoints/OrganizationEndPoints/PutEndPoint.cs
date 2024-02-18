#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Applications.Commands.OrganizationCommands;
using Tiveriad.Identities.Applications.Queries.OrganizationQueries;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Core.StateMachines;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.OrganizationEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/organizations/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrganizationReaderModelContract>> HandleAsync([FromRoute] string id,
        [FromBody] OrganizationUpdaterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var organization = _mapper.Map<OrganizationUpdaterModelContract, Organization>(model);
        organization.Id = id;
        var result = await _mediator.Send(new OrganizationUpdateCommandHandlerRequest(organization), cancellationToken);
        var data = _mapper.Map<Organization, OrganizationReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
    
    [HttpPut("/api/organizations/{id}/events")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrganizationReaderModelContract>> HandleAsync([FromRoute][Required] string id,
        [FromBody] OrganizationEventModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new OrganizationStateUpdateCommandHandlerRequest(id, model.Event), cancellationToken);
        var data = _mapper.Map<Organization, OrganizationReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}