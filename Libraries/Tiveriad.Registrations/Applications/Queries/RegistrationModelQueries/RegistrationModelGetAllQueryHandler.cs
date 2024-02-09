
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using Tiveriad.Registrations.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationModelQueries;

public class RegistrationModelGetAllQueryHandler : IRequestHandler<RegistrationModelGetAllQueryHandlerRequest, List<RegistrationModel>>
{
    private IRepository<RegistrationModel, string> _registrationModelRepository;
    public RegistrationModelGetAllQueryHandler(IRepository<RegistrationModel, string> registrationModelRepository)
    {
        _registrationModelRepository = registrationModelRepository;

    }


    public Task<List<RegistrationModel>> Handle(RegistrationModelGetAllQueryHandlerRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _registrationModelRepository.Queryable;
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.Name != null) query = query.Where(x => x.Name.Contains(request.Name));


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

