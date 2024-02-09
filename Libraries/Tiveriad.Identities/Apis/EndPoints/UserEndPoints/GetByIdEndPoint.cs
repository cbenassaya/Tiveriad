
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Identities.Apis.Contracts.UserContracts;
using Tiveriad.Identities.Applications.Queries.UserQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Apis.EndPoints.UserEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet("/api/users/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserReaderModelContract>> HandleAsync([FromRoute][Required] string id, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result = await _mediator.Send(new UserGetByIdQueryHandlerRequest(id), cancellationToken);
        if (result == null) return NoContent(); var data = _mapper.Map<User, UserReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

