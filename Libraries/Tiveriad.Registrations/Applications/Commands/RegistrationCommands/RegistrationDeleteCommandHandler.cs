
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Registrations.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationCommands;

public class RegistrationDeleteCommandHandler : IRequestHandler<RegistrationDeleteCommandHandlerRequest, bool>
{
    private IRepository<Registration, string> _registrationRepository;
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationDeleteCommandHandler(IRepository<Registration, string> registrationRepository, IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationRepository = registrationRepository;
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<bool> Handle(RegistrationDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    
    var query = _registrationRepository.Queryable.Include(x => x.RegistrationModel).AsQueryable();
    query = query.Where(x => x.Id == request.Id);


    var registration = query.FirstOrDefault();
    if (registration == null) throw new Exception();
    return _registrationRepository.DeleteMany(x => x.Id == request.Id) == 1;
}, cancellationToken);
        
    }
}

