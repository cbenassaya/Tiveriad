
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
using FluentValidation.Resources;
using Tiveriad.Core.Abstractions.Services;

namespace Tiveriad.ReferenceData.Apis.EndPoints.KeyValueEndPoints;

public class GetAllEndPoint<TKeyValue> : ControllerBase
    where TKeyValue : KeyValue
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ITenantService<string> _tenantService;
    private readonly ILanguageService<string> _languageService;
    
    public GetAllEndPoint(IMediator mediator, IMapper mapper, ITenantService<string> tenantService, ILanguageService<string> languageService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _tenantService = tenantService;
        _languageService = languageService;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<KeyValueReaderModelContract>>> HandleAsync( [FromQuery] string? id = null, [FromQuery] string? key = null,  [FromQuery] string? value = null,  [FromQuery] int? page = null, [FromQuery] int? limit = null, [FromQuery] string? q = null, [FromQuery] List<string>? orders = null, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new KeyValueGetAllQueryHandlerRequest(_tenantService.GetTenantId(), id, key, typeof(TKeyValue).Name, value, _languageService.GetLanguage(), page, limit, q, orders), cancellationToken);
        if (!result.Any()) return NoContent();
        var data = _mapper.Map<List<KeyValue>, List<KeyValueReaderModel>>(result);
        data.ForEach(x =>
        {
            var internationalizedValue = x.InternationalizedValues.FirstOrDefault(x => string.IsNullOrEmpty(_languageService.GetLanguage()) ?  x.Default : x.Language.Equals(_languageService.GetLanguage()));
            x.Value = internationalizedValue?.Value ?? string.Empty;
            x.Language = internationalizedValue?.Language ?? string.Empty;
        });
        return Ok(_mapper.Map<List<KeyValueReaderModel>, List<KeyValueReaderModelContract>>(data));
    }
}

