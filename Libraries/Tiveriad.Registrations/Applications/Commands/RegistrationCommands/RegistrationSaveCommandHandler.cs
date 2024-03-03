
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationCommands;

public class RegistrationSaveCommandHandler : IRequestHandler<RegistrationSaveCommandHandlerRequest, Registration>
{
    private IRepository<Registration, string> _registrationRepository;
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationSaveCommandHandler(IRepository<Registration, string> registrationRepository, IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationRepository = registrationRepository;
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<Registration> Handle(RegistrationSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            await _registrationRepository.AddOneAsync(request.Registration, cancellationToken);
            return request.Registration;
        }, cancellationToken);
        
    }
}

