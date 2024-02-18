#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserSaveCommandHandler : IRequestHandler<UserSaveCommandHandlerRequest, User>
{

    private IRepository<Language, string> _languageRepository;
    private IRepository<Locale, string> _localeRepository;
    private readonly IRepository<User, string> _userRepository;

    public UserSaveCommandHandler(IRepository<User, string> userRepository,
        IRepository<Language, string> languageRepository, IRepository<Locale, string> localeRepository)
    {
        _userRepository = userRepository;
        _languageRepository = languageRepository;
        _localeRepository = localeRepository;

    }


    public Task<User> Handle(UserSaveCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            if (request.User.Language != null)
                request.User.Language = await _languageRepository.GetByIdAsync(request.User.Language.Id, cancellationToken);
            if (request.User.Locale != null)
                request.User.Locale = await _localeRepository.GetByIdAsync(request.User.Locale.Id, cancellationToken);
            
            await _userRepository.AddOneAsync(request.User, cancellationToken);
            return request.User;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}