#region

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.DataReferences.Apis.Contracts;
using Tiveriad.DataReferences.Applications.Queries;

#endregion

namespace Tiveriad.DataReferences.Apis.EndPoints;

public class GetAllEndPoint<TEntity, TKey> : ControllerBase
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly IKeyParser<TKey> _keyParser;
    private readonly IMediator _mediator;
    private readonly ITenantService<TKey> _tenantService;


    public GetAllEndPoint(IMediator mediator, ITenantService<TKey> tenantService, IKeyParser<TKey> keyParser)
    {
        _mediator = mediator;
        _tenantService = tenantService;
        _keyParser = keyParser;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<DataReferenceReaderModel>>> HandleAsync(
        [FromQuery] string? id,
        [FromQuery] string? code,
        [FromQuery] int? page, [FromQuery] int? limit,
        [FromQuery] string? q, [FromQuery] string[]? orders,
        CancellationToken cancellationToken)
    {
        
        var result = await _mediator.Send(new GetAllRequest<TEntity, TKey>(
            string.IsNullOrEmpty(id) ? default : _keyParser.Parse(id),
            _tenantService.GetCurrentOrganizationId(),
            code,
            page,
            limit,
            q,
            orders
        ), cancellationToken);
        var data = result.Select(x => new DataReferenceReaderModel
        {
            Id = x.Id != null ? x.Id.ToString() : null,
            Label = x.Label,
            Description = x.Description,
            Code = x.Code,
            Visibility = x.Visibility.ToString()
        }).ToList();
        return Ok(data);
        
    }
}