
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationModelCommands;

public class RegistrationModelSaveCommandHandler : IRequestHandler<RegistrationModelSaveCommandHandlerRequest, RegistrationModel>
{
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationModelSaveCommandHandler(IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<RegistrationModel> Handle(RegistrationModelSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            await _registrationModelRepository.AddOneAsync(request.RegistrationModel, cancellationToken);
            return request.RegistrationModel;
        }, cancellationToken);
        
    }
}

