#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.LanguageContracts;
using Tiveriad.Identities.Applications.Commands.LanguageCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.LanguageEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/languages")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LanguageReaderModelContract>> HandleAsync(
        [FromBody] LanguageWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var language = _mapper.Map<LanguageWriterModelContract, Language>(model);
        var result = await _mediator.Send(new LanguageSaveCommandHandlerRequest(language), cancellationToken);
        var data = _mapper.Map<Language, LanguageReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}