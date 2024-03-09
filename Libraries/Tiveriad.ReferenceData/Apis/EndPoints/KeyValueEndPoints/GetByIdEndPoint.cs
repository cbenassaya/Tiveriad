
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
using Tiveriad.Core.Abstractions.Services;

namespace Tiveriad.ReferenceData.Apis.EndPoints.KeyValueEndPoints;

public class GetByIdEndPoint<TKeyValue> : ControllerBase
    where TKeyValue : KeyValue
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ITenantService<string> _tenantService;
    public GetByIdEndPoint(IMediator mediator, IMapper mapper, ITenantService<string> tenantService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tenantService = tenantService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<KeyInternationalizedValueReaderModelContract>> HandleAsync([FromRoute][Required] string id,  CancellationToken cancellationToken  = default)
    {
        var result = await _mediator.Send(new KeyValueGetByIdQueryHandlerRequest(_tenantService.GetTenantId(), id), cancellationToken);
        if (result == null) return NoContent();
        return Ok(_mapper.Map<KeyValue, KeyInternationalizedValueReaderModelContract>(result));
    }
}

