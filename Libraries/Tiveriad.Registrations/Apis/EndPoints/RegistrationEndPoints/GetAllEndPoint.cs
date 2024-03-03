
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;
using Tiveriad.Registrations.Applications.Queries.RegistrationQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Apis.EndPoints.RegistrationEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet("/api/registrations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<RegistrationReaderModelContract>>> HandleAsync([FromQuery] string? id, [FromQuery] string? organizationName, [FromQuery] string? firstname, [FromQuery] string? lastname, [FromQuery] string? username, [FromQuery] string? password, [FromQuery] string? email, [FromQuery] string? defaultLocale, [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string? q, [FromQuery] IEnumerable<string>? orders, CancellationToken cancellationToken)
    {
        
        var result = await _mediator.Send(new RegistrationGetAllQueryHandlerRequest(id, organizationName, firstname, lastname, username, password, email, defaultLocale, page, limit, q, orders), cancellationToken);
        if (!result.Any()) return NoContent(); var data = _mapper.Map<List<Registration>, List<RegistrationReaderModelContract>>(result);
        return Ok(data);
        
    }
}

