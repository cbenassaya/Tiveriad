#region

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.DataReferences.Apis.Contracts;
using Tiveriad.DataReferences.Applications.Queries;

#endregion

namespace Tiveriad.DataReferences.Apis.EndPoints;

public class GetByIdEndPoint<TEntity, TKey> : ControllerBase
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly IKeyParser<TKey> _keyParser;
    private readonly IMediator _mediator;
    private readonly ITenantService<TKey> _tenantService;


    public GetByIdEndPoint(IMediator mediator, ITenantService<TKey> tenantService, IKeyParser<TKey> keyParser)
    {
        _mediator = mediator;
        _tenantService = tenantService;
        _keyParser = keyParser;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DataReferenceReaderModel>> HandleAsync(
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest("Id is required");
        
        var result =
            await _mediator.Send(
                new GetByIdRequest<TEntity, TKey>(_keyParser.Parse(id), _tenantService.GetCurrentOrganizationId()),
                cancellationToken);
        var data = new DataReferenceReaderModel
        {
            Id = result.Id != null ? result.Id.ToString() : null,
            Label = result.Label,
            Description = result.Description,
            Code = result.Code,
            Visibility = result.Visibility.ToString()
        };
        return Ok(data);
        
    }
}