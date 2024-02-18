#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.OrganizationContracts;
using Tiveriad.Identities.Applications.Commands.OrganizationCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.OrganizationEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/organizations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<OrganizationReaderModelContract>> HandleAsync(
        [FromBody] OrganizationWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var organization = _mapper.Map<OrganizationWriterModelContract, Organization>(model);
        var result = await _mediator.Send(new OrganizationSaveCommandHandlerRequest(organization), cancellationToken);
        var data = _mapper.Map<Organization, OrganizationReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}