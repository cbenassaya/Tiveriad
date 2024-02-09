
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Registrations.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationCommands;

public class RegistrationUpdateCommandHandler : IRequestHandler<RegistrationUpdateCommandHandlerRequest, Registration>
{
    private IRepository<Registration, string> _registrationRepository;
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationUpdateCommandHandler(IRepository<Registration, string> registrationRepository, IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationRepository = registrationRepository;
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<Registration> Handle(RegistrationUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _registrationRepository.Queryable.Include(x => x.RegistrationModel).AsQueryable();



            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Description = request.Registration.Description;
            result.OrganizationName = request.Registration.OrganizationName;
            result.Firstname = request.Registration.Firstname;
            result.Lastname = request.Registration.Lastname;
            result.Username = request.Registration.Username;
            result.Password = request.Registration.Password;
            result.Email = request.Registration.Email;
            result.DefaultLocale = request.Registration.DefaultLocale;
            result.Data = request.Registration.Data;
            if (request.Registration.RegistrationModel != null) result.RegistrationModel = await _registrationModelRepository.GetByIdAsync(request.Registration.RegistrationModel.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

