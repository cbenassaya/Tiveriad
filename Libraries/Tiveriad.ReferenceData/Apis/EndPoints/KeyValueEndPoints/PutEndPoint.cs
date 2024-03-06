
using Tiveriad.ReferenceData.Apis.Contracts.KeyValueContracts;
using Tiveriad.ReferenceData.Core.Entities;
using Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tiveriad.Core.Abstractions.Services;

namespace Tiveriad.ReferenceData.Apis.EndPoints.KeyValueEndPoints;

public class PutEndPoint<TKeyValue> : ControllerBase
    where TKeyValue : KeyValue
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ITenantService<string> _tenantService;
    public PutEndPoint(IMediator mediator, IMapper mapper, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tenantService = tenantService;
    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<KeyInternationalizedValueReaderModelContract>> HandleAsync( [FromRoute] string id, [FromBody] KeyValueWriterModelContract model, CancellationToken cancellationToken)
    {
        var keyValue = _mapper.Map<KeyValueWriterModelContract, KeyValue>(model);
        var result = await _mediator.Send(new KeyValueUpdateCommandHandlerRequest(_tenantService.GetTenantId(), id, keyValue), cancellationToken);
        var data = _mapper.Map<KeyValue, KeyValueReaderModel>(result);
        return Ok(_mapper.Map<KeyValueReaderModel, KeyInternationalizedValueReaderModelContract>(data));
    }
}

