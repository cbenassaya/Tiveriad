
using Tiveriad.Notifications.Apis.Contracts.NotificationContracts;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Notifications.Applications.Commands.NotificationCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Apis.EndPoints.NotificationEndPoints;

public class PostEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPost("/api/notifications")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<NotificationReaderModelContract>> HandleAsync([FromBody] NotificationWriterModelContract model, CancellationToken cancellationToken)
    {
        
        var notification = _mapper.Map<NotificationWriterModelContract, Notification>(model);
        var result = await _mediator.Send(new NotificationSaveCommandHandlerRequest(notification), cancellationToken);
        var data = _mapper.Map<Notification, NotificationReaderModelContract>(result);
        return Ok(data);
        
    }
}

