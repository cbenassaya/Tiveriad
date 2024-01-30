#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints.DocumentCategoryEndPoints;

public class GetAllEndPoint : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/organizations/{organizationId}/documentCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<DocumentCategoryReaderModel>>> HandleAsync(
        [FromRoute] string organizationId, [FromRoute] string? id, [FromQuery] int? page, [FromQuery] int? limit,
        [FromQuery] string? q, [FromQuery] IEnumerable<string>? orders, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var result =
            await _mediator.Send(new GetAllDocumentCategoriesRequest(organizationId, id, page, limit, q, orders),
                cancellationToken);
        if (result == null || !result.Any()) return NoContent();
        var data = _mapper.Map<IEnumerable<DocumentCategory>, IEnumerable<DocumentCategoryReaderModel>>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}