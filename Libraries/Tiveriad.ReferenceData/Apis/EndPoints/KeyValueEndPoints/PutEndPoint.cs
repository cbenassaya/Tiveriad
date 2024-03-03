
using Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;
using Tiveriad.ReferenceData.Core.Entities;
using Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.ReferenceData.Apis.EndPoints.KeyValueEndPoints;

public class PutEndPoint<TKeyValue> : ControllerBase
    where TKeyValue : KeyValue
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<KeyValueReaderModelContract>> HandleAsync([FromRoute] string organizationId, [FromRoute] string id, [FromBody] KeyValueWriterModelContract model, CancellationToken cancellationToken)
    {
        var keyValue = _mapper.Map<KeyValueWriterModelContract, KeyValue>(model);
        var result = await _mediator.Send(new KeyValueUpdateCommandHandlerRequest(organizationId, id, keyValue), cancellationToken);
        var data = _mapper.Map<KeyValue, KeyValueReaderModelContract>(result);
        return Ok(data);
    }
}

