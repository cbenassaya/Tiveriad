
using Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Registrations.Applications.Commands.RegistrationCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Apis.EndPoints.RegistrationEndPoints;

public class PostEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPost("/api/registrations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RegistrationReaderModelContract>> HandleAsync([FromBody] RegistrationWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var registration = _mapper.Map<RegistrationWriterModelContract, Registration>(model);
        var result = await _mediator.Send(new RegistrationSaveCommandHandlerRequest(registration), cancellationToken);
        var data = _mapper.Map<Registration, RegistrationReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

