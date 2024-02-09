
using Tiveriad.Notifications.Apis.Contracts.SubjectContracts;
using Tiveriad.Notifications.Core.Entities;
using Tiveriad.Notifications.Applications.Commands.SubjectCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Notifications.Apis.EndPoints.SubjectEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/api/subjects/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SubjectReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] SubjectWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var subject = _mapper.Map<SubjectWriterModelContract, Subject>(model);
        subject.Id = id;
        var result = await _mediator.Send(new SubjectUpdateCommandHandlerRequest(subject), cancellationToken);
        var data = _mapper.Map<Subject, SubjectReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

