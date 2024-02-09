
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationModelCommands;

public class RegistrationModelUpdateCommandHandler : IRequestHandler<RegistrationModelUpdateCommandHandlerRequest, RegistrationModel>
{
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationModelUpdateCommandHandler(IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<RegistrationModel> Handle(RegistrationModelUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _registrationModelRepository.Queryable;



            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Name = request.RegistrationModel.Name;
            result.Description = request.RegistrationModel.Description;
            result.Model = request.RegistrationModel.Model;

            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

