
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;
using Tiveriad.Registrations.Applications.Queries.RegistrationQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Apis.EndPoints.RegistrationEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet("/api/registrations/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RegistrationReaderModelContract>> HandleAsync([FromRoute][Required] string id, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new RegistrationGetByIdQueryHandlerRequest(id), cancellationToken);
        if (result == null) return NoContent(); var data = _mapper.Map<Registration, RegistrationReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

