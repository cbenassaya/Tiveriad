#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Identities.Apis.Contracts.LocaleContracts;
using Tiveriad.Identities.Applications.Commands.LocaleCommands;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Apis.EndPoints.LocaleEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/locales")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LocaleReaderModelContract>> HandleAsync([FromBody] LocaleWriterModelContract model,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var locale = _mapper.Map<LocaleWriterModelContract, Locale>(model);
        var result = await _mediator.Send(new LocaleSaveCommandHandlerRequest(locale), cancellationToken);
        var data = _mapper.Map<Locale, LocaleReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}