
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Core.Abstractions.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserSaveCommandHandler : IRequestHandler<UserSaveCommandHandlerRequest, User>
{
    private IRepository<User, string> _userRepository;
    private IRepository<Language, string> _languageRepository;
    private IRepository<Locale, string> _localeRepository;
    public UserSaveCommandHandler(IRepository<User, string> userRepository, IRepository<Language, string> languageRepository, IRepository<Locale, string> localeRepository)
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
            await _userRepository.AddOneAsync(request.User, cancellationToken);
            return request.User;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

