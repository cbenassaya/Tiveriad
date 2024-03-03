
using Tiveriad.Registrations.Apis.Contracts.RegistrationModelContracts;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Registrations.Applications.Commands.RegistrationModelCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Apis.EndPoints.RegistrationModelEndPoints;

public class PostEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PostEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPost("/api/registrationModels")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RegistrationModelReaderModelContract>> HandleAsync([FromBody] RegistrationModelWriterModelContract model, CancellationToken cancellationToken)
    {
        
        var registrationModel = _mapper.Map<RegistrationModelWriterModelContract, RegistrationModel>(model);
        var result = await _mediator.Send(new RegistrationModelSaveCommandHandlerRequest(registrationModel), cancellationToken);
        var data = _mapper.Map<RegistrationModel, RegistrationModelReaderModelContract>(result);
        return Ok(data);
        
    }
}

