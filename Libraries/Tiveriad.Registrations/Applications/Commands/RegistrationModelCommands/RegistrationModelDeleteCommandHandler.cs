
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Registrations.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationModelCommands;

public class RegistrationModelDeleteCommandHandler : IRequestHandler<RegistrationModelDeleteCommandHandlerRequest, bool>
{
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationModelDeleteCommandHandler(IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<bool> Handle(RegistrationModelDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    
    var query = _registrationModelRepository.Queryable;
    query = query.Where(x => x.Id == request.Id);


    var registrationModel = query.FirstOrDefault();
    if (registrationModel == null) throw new Exception();
    return _registrationModelRepository.DeleteMany(x => x.Id == request.Id) == 1;
}, cancellationToken);
        
    }
}

