#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.FeatureContracts;
using Tiveriad.Identities.Applications.Commands.FeatureCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.FeatureEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/realms/{realmId}/features")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FeatureReaderModelContract>> HandleAsync(
        [FromRoute] [Required] string? realmId,
        [FromBody] FeatureWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var feature = _mapper.Map<FeatureWriterModelContract, Feature>( model);
        var result = await _mediator.Send(new FeatureSaveCommandHandlerRequest(realmId,feature), cancellationToken);
        var data = _mapper.Map<Feature, FeatureReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}