
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommandHandlerRequest, User>
{
    private IRepository<User, string> _userRepository;
    private IRepository<Language, string> _languageRepository;
    private IRepository<Locale, string> _localeRepository;
    public UserUpdateCommandHandler(IRepository<User, string> userRepository, IRepository<Language, string> languageRepository, IRepository<Locale, string> localeRepository)
    {
        _userRepository = userRepository;
        _languageRepository = languageRepository;
        _localeRepository = localeRepository;

    }


    public Task<User> Handle(UserUpdateCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var query = _userRepository.Queryable.Include(x => x.Language)
    .Include(x => x.Locale).AsQueryable();



            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Firstname = request.User.Firstname;
            result.Lastname = request.User.Lastname;
            result.Username = request.User.Username;
            result.Password = request.User.Password;
            result.Email = request.User.Email;
            result.ProfileImage = request.User.ProfileImage;
            result.Properties = request.User.Properties;
            if (request.User.Language != null) result.Language = await _languageRepository.GetByIdAsync(request.User.Language.Id, cancellationToken);
            if (request.User.Locale != null) result.Locale = await _localeRepository.GetByIdAsync(request.User.Locale.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

