#region

using MediatR;
using Microsoft.EntityFrameworkCore;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Queries.DocumentDescriptionQueries;

public class
    GetAllDocumentDescriptionsRequestHandler : IRequestHandler<GetAllDocumentDescriptionsRequest,
    IEnumerable<DocumentDescription>>
{
    private readonly IRepository<DocumentDescription, string> _documentDescriptionRepository;
    private IRepository<DocumentCategory, string> _documentCategoryRepository;

    public GetAllDocumentDescriptionsRequestHandler(
        IRepository<DocumentDescription, string> documentDescriptionRepository,
        IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentDescriptionRepository = documentDescriptionRepository;
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<IEnumerable<DocumentDescription>> Handle(GetAllDocumentDescriptionsRequest request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _documentDescriptionRepository.Queryable.Include(x => x.DocumentCategory).AsQueryable();
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ? query.OrderByDescending(order.Substring(1)) : query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}