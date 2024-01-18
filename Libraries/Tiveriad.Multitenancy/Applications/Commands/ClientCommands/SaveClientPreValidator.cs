using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.ClientCommands;
public class SaveClientPreValidator : AbstractValidator<SaveClientRequest>
{
    private IRepository<Client, ObjectId> _clientRepository;
    public SaveClientPreValidator(IRepository<Client, ObjectId> clientRepository)
    {
        _clientRepository = clientRepository;
    }
}