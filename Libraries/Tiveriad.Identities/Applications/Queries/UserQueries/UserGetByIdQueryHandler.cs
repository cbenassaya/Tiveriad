
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQueryHandlerRequest, User?>
{
    private IRepository<User, string> _userRepository;
    private IRepository<Language, string> _languageRepository;
    private IRepository<Locale, string> _localeRepository;
    public UserGetByIdQueryHandler(IRepository<User, string> userRepository, IRepository<Language, string> languageRepository, IRepository<Locale, string> localeRepository)
    {
        _userRepository = userRepository;
        _languageRepository = languageRepository;
        _localeRepository = localeRepository;

    }


    public Task<User?> Handle(UserGetByIdQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _userRepository.Queryable.Include(x => x.Language)
        .Include(x => x.Locale).AsQueryable();
        query = query.Where(x => x.Id == request.Id); query = query.Where(x => x.Id == request.Id);


        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

