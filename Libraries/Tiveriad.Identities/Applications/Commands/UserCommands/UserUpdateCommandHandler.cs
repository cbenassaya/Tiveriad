#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommandHandlerRequest, User>
{
    private readonly IRepository<Language, string> _languageRepository;
    private readonly IRepository<Locale, string> _localeRepository;
    private readonly IRepository<User, string> _userRepository;

    public UserUpdateCommandHandler(IRepository<User, string> userRepository,
        IRepository<Language, string> languageRepository, IRepository<Locale, string> localeRepository)
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
            query = query.Where(x => x.Id == request.User.Id);

    
            var result = query.ToList().FirstOrDefault();
            if (result == null) throw new Exception();

            result.Firstname = request.User.Firstname;
            result.Lastname = request.User.Lastname;
            result.Username = request.User.Username;
            result.Password = request.User.Password;
            result.Email = request.User.Email;
            result.Avatar = request.User.Avatar;
            result.DateOfBirth = request.User.DateOfBirth;
            result.Properties = request.User.Properties;
            if (request.User.Language != null)
                result.Language = await _languageRepository.GetByIdAsync(request.User.Language.Id, cancellationToken);
            if (request.User.Locale != null)
                result.Locale = await _localeRepository.GetByIdAsync(request.User.Locale.Id, cancellationToken);
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}