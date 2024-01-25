#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Apis.Filters;

#endregion

namespace Tiveriad.Notifications.Apis.EndPoints.SubjectEndPoints;

public class PutEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PutEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPut("/api/subjects")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ValidateModel]
    public async Task<ActionResult<SubjectReaderModel>> HandleAsync([FromBody] SubjectUpdaterModel model,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var entity = _mapper.Map<SubjectUpdaterModel, Subject>(model);
        var result = await _mediator.Send(new UpdateSubjectRequest(entity), cancellationToken);
        var data = _mapper.Map<Subject, SubjectReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}