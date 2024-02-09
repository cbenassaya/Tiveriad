
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Apis.Contracts.LanguageContracts;
using Tiveriad.Identities.Applications.Queries.LanguageQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.LanguageEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet("/api/languages/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LanguageReaderModelContract>> HandleAsync([FromRoute][Required] string id, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new LanguageGetByIdQueryHandlerRequest(id), cancellationToken);
        if (result == null) return NoContent(); var data = _mapper.Map<Language, LanguageReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

