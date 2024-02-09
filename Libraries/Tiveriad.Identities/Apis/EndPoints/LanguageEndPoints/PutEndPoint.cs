
using Tiveriad.Identities.Apis.Contracts.LanguageContracts;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Applications.Commands.LanguageCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.LanguageEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/api/languages/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LanguageReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] LanguageWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var language = _mapper.Map<LanguageWriterModelContract, Language>(model);
        language.Id = id;
        var result = await _mediator.Send(new LanguageUpdateCommandHandlerRequest(language), cancellationToken);
        var data = _mapper.Map<Language, LanguageReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

