using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Apis.Filters;
using Tiveriad.Multitenancy.Apis.Contracts;
using Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Apis.EndPoints.OrganizationEndPoints;
public class PostEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PostEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/organizations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ValidateModel]
    public async Task<ActionResult<OrganizationReaderModel>> HandleAsync([FromBody] OrganizationWriterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var organization = _mapper.Map<OrganizationWriterModel, Organization>(model);
        var owner = _mapper.Map<UserWriterModel, User>(model.Owner);
        var result = await _mediator.Send(new SaveOrganizationRequest(organization, owner), cancellationToken);
        var data = _mapper.Map<Organization, OrganizationReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}