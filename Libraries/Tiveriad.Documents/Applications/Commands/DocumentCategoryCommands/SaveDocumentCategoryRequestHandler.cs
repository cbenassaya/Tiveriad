using MediatR;

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public class SaveDocumentCategoryRequestHandler : IRequestHandler<SaveDocumentCategoryRequest, DocumentCategory>
{
    private IRepository<DocumentCategory, string> _documentCategoryRepository;
    public SaveDocumentCategoryRequestHandler(IRepository<DocumentCategory, string> documentCategoryRepository)
    {
        _documentCategoryRepository = documentCategoryRepository;
    }


    public Task<DocumentCategory> Handle(SaveDocumentCategoryRequest request, CancellationToken cancellationToken)
    {
        
        return Task.Run(async () =>
        {
            await _documentCategoryRepository.AddOneAsync(request.DocumentCategory, cancellationToken);
            return request.DocumentCategory;
        }, cancellationToken);
        
    }
}

