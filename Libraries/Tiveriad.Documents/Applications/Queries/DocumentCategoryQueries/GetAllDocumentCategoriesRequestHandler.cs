using MediatR;

namespace Tiveriad.Documents.Applications.Queries.DocumentCategoryQueries;

public class GetAllDocumentCategoriesRequestHandler : IRequestHandler<GetAllDocumentCategoriesRequest, IEnumerable<DocumentCategory>?>
{
    private IRepository<DocumentCategory, string> _documentCategoryRepository;
    public GetAllDocumentCategoriesRequestHandler(IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<IEnumerable<DocumentCategory>?> Handle(GetAllDocumentCategoriesRequest request, CancellationToken cancellationToken)
    {
        
        var query = _documentCategoryRepository.Queryable;
        query = query.Where(x => x.OrganizationId == request.OrganizationId);
        if (request.Id != null) query = query.Where(x => x.Id == request.Id);
        if (request.Orders != null && request.Orders.Any())
            foreach (var order in request.Orders)
                query = order.StartsWith("-") ?
                query.OrderByDescending(order.Substring(1)) :
                query.OrderBy(order);
        if (request.Page.HasValue && request.Limit.HasValue)
            query = query.Skip(request.Page.Value * request.Limit.Value).Take(request.Limit.Value);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
        
    }
}

