using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.ClientCommands;

public class UpdateClientPreValidator : AbstractValidator<UpdateClientRequest>
{
    private IRepository<Client, ObjectId> _clientRepository;
    public UpdateClientPreValidator(IRepository<Client, ObjectId> clientRepository)
    {
        _clientRepository = clientRepository;
    }
}