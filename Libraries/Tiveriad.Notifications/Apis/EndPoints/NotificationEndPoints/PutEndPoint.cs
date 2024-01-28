#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Notifications.Apis.Contracts.NotificationContracts;
using Tiveriad.Notifications.Applications.Commands.NotificationCommands;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.EndPoints.NotificationEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/notifications/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<NotificationReaderModel>> HandleAsync([FromRoute] string id,
        [FromBody] NotificationUpdaterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var notification = _mapper.Map<NotificationUpdaterModel, Notification>(model);
        var result = await _mediator.Send(new UpdateNotificationRequest(id, notification), cancellationToken);
        var data = _mapper.Map<Notification, NotificationReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}