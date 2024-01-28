#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Notifications.Apis.Contracts.SubjectContracts;
using Tiveriad.Notifications.Applications.Commands.SubjectCommands;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.EndPoints.SubjectEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/subjects/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SubjectReaderModel>> HandleAsync([FromRoute] string id,
        [FromBody] SubjectUpdaterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var subject = _mapper.Map<SubjectUpdaterModel, Subject>(model);
        var result = await _mediator.Send(new UpdateSubjectRequest(id, subject), cancellationToken);
        var data = _mapper.Map<Subject, SubjectReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}