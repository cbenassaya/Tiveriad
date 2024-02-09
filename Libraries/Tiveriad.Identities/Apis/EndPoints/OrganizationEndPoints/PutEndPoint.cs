
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Applications.Commands.OrganizationCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.OrganizationEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/api/organizations/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrganizationReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] OrganizationWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var organization = _mapper.Map<OrganizationWriterModelContract, Organization>(model);
        organization.Id = id;
        var result = await _mediator.Send(new OrganizationUpdateCommandHandlerRequest(organization), cancellationToken);
        var data = _mapper.Map<Organization, OrganizationReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}
