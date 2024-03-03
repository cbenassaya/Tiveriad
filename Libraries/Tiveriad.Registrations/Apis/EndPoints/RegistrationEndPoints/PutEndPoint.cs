
using Tiveriad.Registrations.Apis.Contracts.RegistrationContracts;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Registrations.Applications.Commands.RegistrationCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Apis.EndPoints.RegistrationEndPoints;

public class PutEndPoint : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;
    public PutEndPoint(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;

    }

    [HttpPut("/api/registrations/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RegistrationReaderModelContract>> HandleAsync([FromRoute] string id, [FromBody] RegistrationWriterModelContract model, CancellationToken cancellationToken)
    {
        

        var registration = _mapper.Map<RegistrationWriterModelContract, Registration>(model);
        registration.Id = id;
        var result = await _mediator.Send(new RegistrationUpdateCommandHandlerRequest(registration), cancellationToken);
        var data = _mapper.Map<Registration, RegistrationReaderModelContract>(result);
        return Ok(data);
        
    }
}

