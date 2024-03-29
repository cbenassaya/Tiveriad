using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public class DeleteDocumentCategoryByIdRequestHandler : IRequestHandler<DeleteDocumentCategoryByIdRequest, bool>
{
    private IRepository<DocumentCategory, string> _documentCategoryRepository;
    public DeleteDocumentCategoryByIdRequestHandler(IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<bool> Handle(DeleteDocumentCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
{
    
    var query = _documentCategoryRepository.Queryable;
    query = query.Where(x => x.OrganizationId == request.OrganizationId);
    query = query.Where(x => x.Id == request.Id);
    var documentCategory = query.FirstOrDefault();
    if (documentCategory == null) throw new Exception();
    return _documentCategoryRepository.DeleteMany(x => x.OrganizationId == request.OrganizationId && x.Id == request.Id) == 1;
}, cancellationToken);
        
    }
}

