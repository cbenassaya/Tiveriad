
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

public class PostEndPoint<TKeyValue> : ControllerBase
    where TKeyValue : KeyValue
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<KeyValueReaderModelContract>> HandleAsync([FromRoute] string organizationId, [FromBody] KeyValueWriterModelContract model, CancellationToken cancellationToken)
    {
        var keyValue = _mapper.Map<KeyValueWriterModelContract, KeyValue>(model);
        keyValue.Entity= typeof(TKeyValue).Name;
        var result = await _mediator.Send(new KeyValueSaveCommandHandlerRequest(organizationId, keyValue), cancellationToken);
        var data = _mapper.Map<KeyValue, KeyValueReaderModelContract>(result);
        return Ok(data);
    }
}

