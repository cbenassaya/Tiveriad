using FluentValidation;
using Tiveriad.Multitenancy.Core.Entities;
using Tiveriad.Repositories;

namespace Tiveriad.Multitenancy.Applications.Queries.UserQueries;
public class GetAllUsersPreValidator : AbstractValidator<GetAllUsersRequest>
{
    private IRepository<User, ObjectId> _userRepository;
    public GetAllUsersPreValidator(IRepository<User, ObjectId> userRepository)
    {
        _userRepository = userRepository;
    }
}