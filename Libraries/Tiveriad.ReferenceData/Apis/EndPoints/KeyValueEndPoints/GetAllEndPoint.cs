
using Tiveriad.ReferenceData.Core.Entities;
using Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;
using Tiveriad.ReferenceData.Applications.Queries.KeyValueQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.ReferenceData.Apis.EndPoints.KeyValueEndPoints;

public class GetAllEndPoint<TKeyValue> : ControllerBase
    where TKeyValue : KeyValue
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetAllEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<KeyValueReaderModelContract>>> HandleAsync([FromRoute] string organizationId, [FromQuery] string? id = null, [FromQuery] string? key = null,  [FromQuery] string? value = null, [FromQuery] string? language = null, [FromQuery] int? page = null, [FromQuery] int? limit = null, [FromQuery] string? q = null, [FromQuery] List<string>? orders = null, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new KeyValueGetAllQueryHandlerRequest(organizationId, id, key, typeof(TKeyValue).Name, value, language, page, limit, q, orders), cancellationToken);
        if (!result.Any()) return NoContent();
        var data = _mapper.Map<List<KeyValue>, List<KeyValueReaderModel>>(result);
        data.ForEach(x =>
        {
            x.Value = x.InternationalizedValues.FirstOrDefault(x => string.IsNullOrEmpty(language) ?  x.Default : x.Language.Equals(language))?.Value;
        });
        return Ok(_mapper.Map<List<KeyValueReaderModel>, List<KeyValueReaderModelContract>>(data));
    }
}

