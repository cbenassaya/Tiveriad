
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationModelQueries;

public class RegistrationModelGetByIdQueryHandler : IRequestHandler<RegistrationModelGetByIdQueryHandlerRequest, RegistrationModel?>
{
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationModelGetByIdQueryHandler(IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<RegistrationModel?> Handle(RegistrationModelGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _registrationModelRepository.Queryable;
        query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

