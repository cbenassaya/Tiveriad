
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Applications.Queries.UserQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.UserEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet("/users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResult<UserReaderModelContract>>> HandleAsync([FromQuery] string? id = null, [FromQuery] string? firstname = null, [FromQuery] string? lastname = null, [FromQuery] string? username = null, [FromQuery] string? language = null, [FromQuery] string? locale = null, [FromQuery] string? email = null, [FromQuery] int? page = null, [FromQuery] int? limit = null, [FromQuery] string? q = null, [FromQuery] List<string>? orders = null, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new UserGetAllQueryHandlerRequest(id, firstname, lastname, username, language, locale, email, page, limit, q, orders), cancellationToken);
        if (result.Items.Count==0) return NoContent();
        var data = _mapper.Map<PagedResult<User>, PagedResult<UserReaderModelContract>>(result);
        return Ok(data);
    }
}

