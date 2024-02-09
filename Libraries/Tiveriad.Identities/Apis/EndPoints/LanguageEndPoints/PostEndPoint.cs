
using Tiveriad.Identities.Apis.Contracts.LanguageContracts;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Applications.Commands.LanguageCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.LanguageEndPoints;

public class PostEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPost("/api/languages")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LanguageReaderModelContract>> HandleAsync([FromBody] LanguageWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var language = _mapper.Map<LanguageWriterModelContract, Language>(model);
        var result = await _mediator.Send(new LanguageSaveCommandHandlerRequest(language), cancellationToken);
        var data = _mapper.Map<Language, LanguageReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

