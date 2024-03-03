
using Tiveriad.Notifications.Apis.Contracts.SubjectContracts;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Notifications.Applications.Commands.SubjectCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Apis.EndPoints.SubjectEndPoints;

public class PostEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPost("/api/subjects")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SubjectReaderModelContract>> HandleAsync([FromBody] SubjectWriterModelContract model, CancellationToken cancellationToken)
    {
        
        var subject = _mapper.Map<SubjectWriterModelContract, Subject>(model);
        var result = await _mediator.Send(new SubjectSaveCommandHandlerRequest(subject), cancellationToken);
        var data = _mapper.Map<Subject, SubjectReaderModelContract>(result);
        return Ok(data);
        
    }
}

