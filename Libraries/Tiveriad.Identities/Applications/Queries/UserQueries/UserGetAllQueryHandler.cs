
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQueryHandlerRequest, List<User>>
{
    private IRepository<User, string> _userRepository;
    private IRepository<Language, string> _languageRepository;
    private IRepository<Locale, string> _localeRepository;
    public UserGetAllQueryHandler(IRepository<User, string> userRepository, IRepository<Language, string> languageRepository, IRepository<Locale, string> localeRepository)
    {
        _userRepository = userRepository;
        _languageRepository = languageRepository;
        _localeRepository = localeRepository;

    }


    public Task<List<User>> Handle(UserGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _userRepository.Queryable.Include(x => x.Language)
        .Include(x => x.Locale).AsQueryable();
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.Firstname != null) query = query.Where(x => x.Firstname.Contains(request.Firstname));
        if (request.Lastname != null) query = query.Where(x => x.Lastname.Contains(request.Lastname));
        if (request.Username != null) query = query.Where(x => x.Username.Contains(request.Username));
        if (request.Password != null) query = query.Where(x => x.Password.Contains(request.Password));
        if (request.Email != null) query = query.Where(x => x.Email.Contains(request.Email));


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ?
                query.OrderByDescending(order.Substring(1)) :
                query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

