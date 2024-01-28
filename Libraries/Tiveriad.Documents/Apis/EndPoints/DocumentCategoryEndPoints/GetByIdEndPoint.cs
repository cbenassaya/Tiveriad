#region

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Documents.Apis.Contracts.DocumentCategoryContracts;
using Tiveriad.Documents.Applications.Queries.DocumentCategoryQueries;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentCategoryEndPoints;

public class GetByIdEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/documentcategories/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentCategoryReaderModel>> HandleAsync([FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id)) return BadRequest("Id is mandatory");
        var result = await _mediator.Send(new GetDocumentCategoryByIdRequest(id), cancellationToken);
        if (result == null) return NoContent();
        var data = _mapper.Map<DocumentCategory, DocumentCategoryReaderModel>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}