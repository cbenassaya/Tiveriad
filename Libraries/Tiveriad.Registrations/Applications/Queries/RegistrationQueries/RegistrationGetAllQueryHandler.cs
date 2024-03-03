
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Registrations.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationQueries;

public class RegistrationGetAllQueryHandler : IRequestHandler<RegistrationGetAllQueryHandlerRequest, List<Registration>>
{
    private IRepository<Registration, string> _registrationRepository;
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationGetAllQueryHandler(IRepository<Registration, string> registrationRepository, IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationRepository = registrationRepository;
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<List<Registration>> Handle(RegistrationGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        
        var query = _registrationRepository.Queryable.Include(x => x.RegistrationModel).AsQueryable();
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.OrganizationName != null) query = query.Where(x => x.OrganizationName.Contains(request.OrganizationName));
        if (request.Firstname != null) query = query.Where(x => x.Firstname.Contains(request.Firstname));
        if (request.Lastname != null) query = query.Where(x => x.Lastname.Contains(request.Lastname));
        if (request.Username != null) query = query.Where(x => x.Username.Contains(request.Username));
        if (request.Password != null) query = query.Where(x => x.Password.Contains(request.Password));
        if (request.Email != null) query = query.Where(x => x.Email.Contains(request.Email));
        if (request.DefaultLocale != null) query = query.Where(x => x.DefaultLocale.Contains(request.DefaultLocale));


        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ?
                query.OrderByDescending(order.Substring(1)) :
                query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList(), cancellationToken);
        
    }
}

