#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Notifications.Apis.Contracts.SubjectContracts;
using Tiveriad.Notifications.Application.Queries.SubjectQueries;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Apis.EndPoints.SubjectEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/subjects/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SubjectReaderModel>> HandleAsync([FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new GetSubjectByIdRequest(id), cancellationToken);
        if (result == null) return NoContent();
        var data = _mapper.Map<Subject, SubjectReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}