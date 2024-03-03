using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Tiveriad.Documents.Applications.Queries.DocumentDescriptionQueries;

public class GetDocumentDescriptionByIdRequestHandler : IRequestHandler<GetDocumentDescriptionByIdRequest, DocumentDescription?>
{
    private IRepository<DocumentDescription, string> _documentDescriptionRepository;
    private IRepository<DocumentCategory, string> _documentCategoryRepository;
    public GetDocumentDescriptionByIdRequestHandler(IRepository<DocumentDescription, string> documentDescriptionRepository, IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentDescriptionRepository = documentDescriptionRepository;
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<DocumentDescription?> Handle(GetDocumentDescriptionByIdRequest request, CancellationToken cancellationToken)
    {
        
        var query = _documentDescriptionRepository.Queryable.Include(x => x.DocumentCategory).AsQueryable();
        query = query.Where(x => x.OrganizationId == request.OrganizationId);
        query = query.Where(x => x.Id == request.Id);
        return Task.Run(() => query.ToList().FirstOrDefault(), cancellationToken);
        
    }
}

