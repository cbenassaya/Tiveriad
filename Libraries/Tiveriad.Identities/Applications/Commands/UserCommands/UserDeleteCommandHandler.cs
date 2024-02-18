#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommandHandlerRequest, bool>
{
    private IRepository<Language, string> _languageRepository;
    private IRepository<Locale, string> _localeRepository;
    private readonly IRepository<User, string> _userRepository;

    public UserDeleteCommandHandler(IRepository<User, string> userRepository,
        IRepository<Language, string> languageRepository, IRepository<Locale, string> localeRepository)
    {
        _userRepository = userRepository;
        _languageRepository = languageRepository;
        _localeRepository = localeRepository;
    }


    public Task<bool> Handle(UserDeleteCommandHandlerRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            //<-- START CUSTOM CODE-->
            var query = _userRepository.Queryable.Include(x => x.Language)
                .Include(x => x.Locale).AsQueryable();
            query = query.Where(x => x.Id == request.Id);


            var user = query.FirstOrDefault();
            if (user == null) throw new Exception();
            return _userRepository.DeleteMany(x => x.Id == request.Id) == 1;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}