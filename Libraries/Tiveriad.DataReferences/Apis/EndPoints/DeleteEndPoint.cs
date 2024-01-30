#region

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.DataReferences.Applications.Commands;

#endregion

namespace Tiveriad.DataReferences.Apis.EndPoints;

public class DeleteEndPoint<TEntity, TKey> : ControllerBase
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly IKeyParser<TKey> _keyParser;
    private readonly IMediator _mediator;
    private readonly ITenantService<TKey> _tenantService;

    public DeleteEndPoint(IMediator mediator, ITenantService<TKey> tenantService, IKeyParser<TKey> keyParser)
    {
        _mediator = mediator;
        _tenantService = tenantService;
        _keyParser = keyParser;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TEntity>> HandleAsync(
        [FromRoute] [Required] string id,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest("Id is required");
        //<-- START CUSTOM CODE-->
        var result =
            await _mediator.Send(
                new DeleteByIdRequest<TEntity, TKey>(_keyParser.Parse(id), _tenantService.GetCurrentOrganizationId()),
                cancellationToken);
        return Ok(result);
        //<-- END CUSTOM CODE-->
    }
}