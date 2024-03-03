
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationQueries;

public class RegistrationGetByIdQueryHandler : IRequestHandler<RegistrationGetByIdQueryHandlerRequest, Registration?>
{
    private IRepository<Registration, string> _registrationRepository;
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationGetByIdQueryHandler(IRepository<Registration, string> registrationRepository, IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationRepository = registrationRepository;
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<Registration?> Handle(RegistrationGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        
        var query = _registrationRepository.Queryable.Include(x => x.RegistrationModel).AsQueryable();
        query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        
    }
}

