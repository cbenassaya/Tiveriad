
using Tiveriad.Registrations.Apis.Contracts.RegistrationModelContracts;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Registrations.Applications.Commands.RegistrationModelCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Apis.EndPoints.RegistrationModelEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/api/registrationModels/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RegistrationModelReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] RegistrationModelWriterModelContract model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->

        var registrationModel = _mapper.Map<RegistrationModelWriterModelContract, RegistrationModel>(model);
        registrationModel.Id = id;
        var result = await _mediator.Send(new RegistrationModelUpdateCommandHandlerRequest(registrationModel), cancellationToken);
        var data = _mapper.Map<RegistrationModel, RegistrationModelReaderModelContract>(result);
        return Ok(data);
        //<-- END CUSTOM CODE-->
    }
}

