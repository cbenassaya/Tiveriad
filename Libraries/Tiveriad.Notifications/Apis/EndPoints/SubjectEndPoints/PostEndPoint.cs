#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Apis.Filters;
using Tiveriad.Notifications.Applications.Commands.SubjectCommands;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.EndPoints.SubjectEndPoints;

public class PostEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PostEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/subjects")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ValidateModel]
    public async Task<ActionResult<SubjectReaderModel>> HandleAsync([FromBody] SubjectWriterModel model,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var subject = _mapper.Map<SubjectWriterModel, Subject>(model);
        var owner = _mapper.Map<UserWriterModel, User>(model.Owner);
        var result = await _mediator.Send(new SaveSubjectRequest(subject, owner), cancellationToken);
        var data = _mapper.Map<Subject, SubjectReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}