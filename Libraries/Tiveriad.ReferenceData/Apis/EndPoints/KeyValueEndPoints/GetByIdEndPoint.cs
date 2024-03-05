
using Tiveriad.ReferenceData.Core.Entities;
using Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;
using Tiveriad.ReferenceData.Applications.Queries.KeyValueQueries;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.ReferenceData.Apis.EndPoints.KeyValueEndPoints;

public class GetByIdEndPoint<TKeyValue> : ControllerBase
    where TKeyValue : KeyValue
{
    private IMediator _mediator;
    private IMapper _mapper;
    public GetByIdEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<KeyInternationalizedValueReaderModelContract>> HandleAsync([FromRoute][Required] string organizationId, [FromRoute][Required] string id,  CancellationToken cancellationToken  = default)
    {
        var result = await _mediator.Send(new KeyValueGetByIdQueryHandlerRequest(organizationId, id), cancellationToken);
        if (result == null) return NoContent();
        var data = _mapper.Map<KeyValue, KeyValueReaderModel>(result);
        return Ok(_mapper.Map<KeyValueReaderModel, KeyInternationalizedValueReaderModelContract>(data));
    }
}

