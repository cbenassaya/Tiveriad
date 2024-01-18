using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Commands.UserCommands;
public class DeleteUserByIdPreValidator : AbstractValidator<DeleteUserByIdRequest>
{
    private IRepository<User, ObjectId> _userRepository;
    public DeleteUserByIdPreValidator(IRepository<User, ObjectId> userRepository)
    {
        _userRepository = userRepository;
    }
}