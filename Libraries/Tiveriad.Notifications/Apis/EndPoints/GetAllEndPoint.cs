#region

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.Documents.Apis.Contracts;
using Tiveriad.Documents.Applications.Queries;

#endregion

namespace Tiveriad.Documents.Apis.EndPoints
{
    public class GetAllEndPoint<T> : ControllerBase where T : IEquatable<T>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<GetAllEndPoint<T>> _logger;
        private readonly IKeyParser<T> _keyParser;


        public GetAllEndPoint(IMapper mapper, IMediator mediator, ILogger<GetAllEndPoint<T>> logger, IKeyParser<T> keyParser)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _keyParser = keyParser;
        }

        [HttpGet("/api/documentDescriptions")]
        public async Task<ActionResult<IEnumerable<DocumentDescriptionReaderModel>>> HandleAsync(
            [FromQuery] string? id,
            [FromQuery] string? name,
            [FromQuery] string? reference,
            [FromQuery] string? referenceType,
            [FromQuery] int? page, [FromQuery] int? limit,
            [FromQuery] string? q, [FromQuery] string[]? orders,
            CancellationToken cancellationToken)
        {
            //<-- START CUSTOM CODE-->
            var result = await _mediator.Send(new GetAllDocumentDescriptionRequest<T>(
                 Id:_keyParser.Parse(id),
                 Name:name,
                 Reference:reference,
                 ReferenceType:referenceType,
                 Page:page,
                 Limit:limit,
                 Q:q,
                 Orders:orders), cancellationToken);
            var data =
                _mapper.Map<IEnumerable<DocumentDescriptionBase<T>>, IEnumerable<DocumentDescriptionReaderModel>>(result);
            return Ok(data);
            //<-- END CUSTOM CODE-->
        }
    }
}

