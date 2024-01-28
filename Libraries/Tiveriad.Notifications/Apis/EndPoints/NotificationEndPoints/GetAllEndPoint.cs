#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Notifications.Apis.Contracts.NotificationContracts;
using Tiveriad.Notifications.Application.Queries.NotificationQueries;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.EndPoints.NotificationEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/notifications")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<NotificationReaderModel>>> HandleAsync([FromRoute] string? id,
        [FromQuery] int? page, [FromQuery] int? limit, [FromQuery] string q, [FromQuery] IEnumerable<string>? orders,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result =
            await _mediator.Send(new GetAllNotificationsRequest(id, page, limit, q, orders), cancellationToken);
        if (result == null || !result.Any()) return NoContent();
        var data = _mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationReaderModel>>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}