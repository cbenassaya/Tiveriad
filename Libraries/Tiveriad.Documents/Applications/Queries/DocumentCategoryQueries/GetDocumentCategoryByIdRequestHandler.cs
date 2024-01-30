using MediatR;

namespace Tiveriad.Documents.Applications.Queries.DocumentCategoryQueries;

public class GetDocumentCategoryByIdRequestHandler : IRequestHandler<GetDocumentCategoryByIdRequest, DocumentCategory?>
{
    private IRepository<DocumentCategory, string> _documentCategoryRepository;
    public GetDocumentCategoryByIdRequestHandler(IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<DocumentCategory?> Handle(GetDocumentCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var query = _documentCategoryRepository.Queryable;
        query = query.Where(x => x.OrganizationId == request.OrganizationId);
        query = query.Where(x => x.Id == request.Id);
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}

