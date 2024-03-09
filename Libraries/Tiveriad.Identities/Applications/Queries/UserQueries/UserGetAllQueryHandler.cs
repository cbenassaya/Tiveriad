
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

public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQueryHandlerRequest, PagedResult<User>>
{
    private IRepository<User, string> _userRepository;
    public UserGetAllQueryHandler(IRepository<User, string> userRepository)
    {
        _userRepository = userRepository;

    }


    public Task<PagedResult<User>> Handle(UserGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        var query = _userRepository.Queryable;
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.Firstname != null) query = query.Where(x => x.Firstname.Contains(request.Firstname));
        if (request.Lastname != null) query = query.Where(x => x.Lastname.Contains(request.Lastname));
        if (request.Username != null) query = query.Where(x => x.Username.Contains(request.Username));
        if (request.Language != null) query = query.Where(x => x.Language.Contains(request.Language));
        if (request.Locale != null) query = query.Where(x => x.Locale.Contains(request.Locale));
        if (request.Email != null) query = query.Where(x => x.Email.Contains(request.Email));


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ?
                query.OrderByDescending(order.Substring(1)) :
                query.OrderBy(order);
        return Task.Run(() => query.GetPaged(), cancellationToken);
    }
}

