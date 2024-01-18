using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.ClientCommands;
public class DeleteClientByIdPreValidator : AbstractValidator<DeleteClientByIdRequest>
{
    private IRepository<Client, ObjectId> _clientRepository;
    public DeleteClientByIdPreValidator(IRepository<Client, ObjectId> clientRepository)
    {
        _clientRepository = clientRepository;
    }
}