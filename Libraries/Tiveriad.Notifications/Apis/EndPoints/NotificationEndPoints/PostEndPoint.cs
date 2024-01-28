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

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/notifications")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<NotificationReaderModel>> HandleAsync([FromBody] NotificationWriterModel model,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var notification = _mapper.Map<NotificationWriterModel, Notification>(model);
        var result = await _mediator.Send(new SaveNotificationRequest(notification), cancellationToken);
        var data = _mapper.Map<Notification, NotificationReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}