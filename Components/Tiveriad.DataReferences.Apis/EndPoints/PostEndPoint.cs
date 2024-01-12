#region

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiveriad.DataReferences.Apis.Commands;
using Tiveriad.DataReferences.Apis.Contracts;
using Tiveriad.DataReferences.Apis.Services;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.DataReferences.Apis.EndPoints;

public  class PostEndPoint<TEntity, TKey> : ControllerBase
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>
{
    private readonly IMediator _mediator;
    private readonly ITenantService<TKey> _tenantService;
    private readonly IKeyParser<TKey> _keyParser;

    public PostEndPoint(IMediator mediator, ITenantService<TKey> tenantService, IKeyParser<TKey> keyParser)
    {
        _mediator = mediator;
        _tenantService = tenantService;
        _keyParser = keyParser;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DataReferenceReaderModel>> HandleAsync(
        [FromBody] DataReferenceWriterModel model, CancellationToken cancellationToken)
    {
        TEntity entity = new()
        {
            Label = model.Label,
            Description = model.Description,
            Code = model.Code,
        };
        entity.OrganizationId = _tenantService.GetOrganizationId();
        var result = await _mediator.Send(new SaveRequest<TEntity, TKey>(entity), cancellationToken);
        var data = new DataReferenceReaderModel
        {
            Id = result.Id != null ? result.Id.ToString() : null,
            Label = result.Label,
            Description = result.Description,
            Code = result.Code,
            Visibility = result.Visibility.ToString()
        };
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}