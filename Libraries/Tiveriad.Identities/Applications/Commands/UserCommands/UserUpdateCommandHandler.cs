
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommandHandlerRequest, User>
{
    private IRepository<User, string> _userRepository;
    public UserUpdateCommandHandler(IRepository<User, string> userRepository)
    {
        _userRepository = userRepository;

    }


    public Task<User> Handle(UserUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            var query = _userRepository.Queryable;
            query = query.Where(x => x.Id == request.Id);


            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Firstname = request.User.Firstname;
            result.Lastname = request.User.Lastname;
            result.Username = request.User.Username;
            result.Password = request.User.Password;
            result.Language = request.User.Language;
            result.Locale = request.User.Locale;
            result.Email = request.User.Email;
            result.Avatar = request.User.Avatar;
            result.DateOfBirth = request.User.DateOfBirth;
            result.Properties = request.User.Properties;

            return result;
        }, cancellationToken);
    }
}

