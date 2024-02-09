
using Tiveriad.Identities.Apis.Contracts.LocaleContracts;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Applications.Commands.LocaleCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.LocaleEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/api/locales/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LocaleReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] LocaleWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var locale = _mapper.Map<LocaleWriterModelContract, Locale>(model);
        locale.Id = id;
        var result = await _mediator.Send(new LocaleUpdateCommandHandlerRequest(locale), cancellationToken);
        var data = _mapper.Map<Locale, LocaleReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

